using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Security
{
    public static class Security
    {
        /// <summary>
        /// Defining constants for our security standard
        /// </summary>
        private const int m_KeySize = 256;
        private const int m_Iterations = 1024;

        /// <summary>
        /// Generates a random array of 256 bits (32 bytes) of random data
        /// </summary>
        /// <returns></returns>
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            byte[] randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        /// <summary>
        /// Encrypts a string with a given pass-phrase
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="passPhrase"></param>
        public static void EncryptString(string plainText, string passPhrase)
        {
            //generate a random salt
            byte[] saltStringBytes = Generate256BitsOfRandomEntropy();
            //generate inital vector 
            byte[] ivStringBytes = Generate256BitsOfRandomEntropy();
            //convert plainText to byte form
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            
            //generate the password from the passPhrase and the salt
            using(Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, m_Iterations))
            {
                //convert our pasword to bytes
                byte[] keyBytes = password.GetBytes(m_KeySize / 8);

                using(var symmetricKey = new RijndaelManaged())
                {
                    //setup the key
                    symmetricKey.BlockSize = m_KeySize;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using(CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                //create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                byte[] cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();

                                memoryStream.Close();
                                cryptoStream.Close();

                                //write encrypted data to file
                                using(FileStream fileStream = new FileStream("encrypted.enc", FileMode.Create))
                                {
                                    fileStream.Write(cipherTextBytes, 0, cipherTextBytes.Length);
                                }
                            }
                        }
                    }

                }

            }
        }

        /// <summary>
        /// Decrypts a string with a given pass-phrase
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="passPhrase"></param>
        public static void DecryptString(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            byte[] cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            byte[] saltStringBytes = cipherTextBytesWithSaltAndIv.Take(m_KeySize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            byte[] ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(m_KeySize / 8).Take(m_KeySize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            byte[] cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((m_KeySize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((m_KeySize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, m_Iterations))
            {
                byte[] keyBytes = password.GetBytes(m_KeySize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                //write encrypted data to file
                                using(FileStream fileStream = new FileStream("decrypted.enc", FileMode.Create))
                                {
                                    fileStream.Write(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Encrypts a file with a given pass-phrase.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="passPhrase"></param>
        public static void EncryptFile(string filePath, string passPhrase)
        {
            //generate a random salt
            byte[] saltStringBytes = Generate256BitsOfRandomEntropy();
            //generate inital vector 
            byte[] ivStringBytes = Generate256BitsOfRandomEntropy();

            byte[] filePlainBytes = File.ReadAllBytes(filePath);

            //generate the password from the passPhrase and the salt
            using (Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, m_Iterations))
            {
                //convert our pasword to bytes
                byte[] keyBytes = password.GetBytes(m_KeySize / 8);

                using (var symmetricKey = new RijndaelManaged())
                {
                    //setup the key
                    symmetricKey.BlockSize = m_KeySize;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(filePlainBytes, 0, filePlainBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                //create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                byte[] cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();

                                memoryStream.Close();
                                cryptoStream.Close();

                                //write encrypted data to file
                                using (FileStream fileStream = new FileStream("encrypted.enc", FileMode.Create))
                                {
                                    fileStream.Write(cipherTextBytes, 0, cipherTextBytes.Length);
                                }
                            }
                        }
                    }

                }

            }
        }

        /// <summary>
        /// Decrypts a file with a given pass-phrase.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="passPhrase"></param>
        public static void DecryptFile(string filePath, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]

            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            byte[] cipherTextBytesWithSaltAndIv = File.ReadAllBytes(filePath);
            byte[] saltStringBytes = cipherTextBytesWithSaltAndIv.Take(m_KeySize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            byte[] ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(m_KeySize / 8).Take(m_KeySize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            byte[] cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((m_KeySize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((m_KeySize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, m_Iterations))
            {
                byte[] keyBytes = password.GetBytes(m_KeySize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                //write encrypted data to file
                                using (FileStream fileStream = new FileStream("decrypted.den", FileMode.Create))
                                {
                                    fileStream.Write(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Computes an un-salted SHA256 hash for file comparison.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GenerateSHA256(string filePath)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }
    }
}
