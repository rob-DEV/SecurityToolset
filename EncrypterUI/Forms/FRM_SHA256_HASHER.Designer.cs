namespace EncrypterUI.Forms
{
    partial class FRM_SHA256_HASHER
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFileToEncrypt = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.btnComputeHash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFileToEncrypt
            // 
            this.lblFileToEncrypt.AutoSize = true;
            this.lblFileToEncrypt.Location = new System.Drawing.Point(12, 50);
            this.lblFileToEncrypt.Name = "lblFileToEncrypt";
            this.lblFileToEncrypt.Size = new System.Drawing.Size(0, 13);
            this.lblFileToEncrypt.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(215, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Choose File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtHash
            // 
            this.txtHash.Location = new System.Drawing.Point(12, 77);
            this.txtHash.Multiline = true;
            this.txtHash.Name = "txtHash";
            this.txtHash.Size = new System.Drawing.Size(215, 86);
            this.txtHash.TabIndex = 4;
            // 
            // btnComputeHash
            // 
            this.btnComputeHash.Location = new System.Drawing.Point(69, 192);
            this.btnComputeHash.Name = "btnComputeHash";
            this.btnComputeHash.Size = new System.Drawing.Size(103, 23);
            this.btnComputeHash.TabIndex = 5;
            this.btnComputeHash.Text = "Compute Hash";
            this.btnComputeHash.UseVisualStyleBackColor = true;
            this.btnComputeHash.Click += new System.EventHandler(this.btnComputeHash_Click);
            // 
            // FRM_SHA256_HASHER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 228);
            this.Controls.Add(this.btnComputeHash);
            this.Controls.Add(this.txtHash);
            this.Controls.Add(this.lblFileToEncrypt);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FRM_SHA256_HASHER";
            this.Text = "SHA256 File Hasher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileToEncrypt;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.Button btnComputeHash;
    }
}