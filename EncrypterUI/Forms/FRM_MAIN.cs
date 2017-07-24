using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncrypterUI.Forms
{
    public partial class FRM_MAIN : Form
    {
        private String filePath = String.Empty;

        public FRM_MAIN()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        /// <summary>
        /// Opens a file for a job
        /// </summary>
        private void OpenFile()
        {
            OpenFileDialog fileDiag = new OpenFileDialog();

            if(fileDiag.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDiag.FileName;
                lblFileToEncrypt.Text = fileDiag.FileName;
                
            }
        }

        /// <summary>
        /// Open the SHA256 hashing form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sha256StripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_SHA256_HASHER frmSHA256 = new FRM_SHA256_HASHER();
            frmSHA256.ShowDialog();
        }

        /// <summary>
        /// Exit the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnDoJob_Click(object sender, EventArgs e)
        {
            if(filePath.Length > 0 && txtPassphrase.Text.Length > 0)
            {
                if(checkEncrypt.Checked)
                    Security.Security.EncryptFile(filePath, txtPassphrase.Text);
                else if(checkDecrypt.Checked)
                    Security.Security.DecryptFile(filePath, txtPassphrase.Text);
            }
        }
    }
}
