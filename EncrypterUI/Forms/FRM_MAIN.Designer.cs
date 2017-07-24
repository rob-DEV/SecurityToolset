namespace EncrypterUI.Forms
{
    partial class FRM_MAIN
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileToEncrypt = new System.Windows.Forms.Label();
            this.btnDoJob = new System.Windows.Forms.Button();
            this.txtPassphrase = new System.Windows.Forms.TextBox();
            this.lblPassphrase = new System.Windows.Forms.Label();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SHA256HasherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDecrypt = new System.Windows.Forms.CheckBox();
            this.checkEncrypt = new System.Windows.Forms.CheckBox();
            this.groupOption = new System.Windows.Forms.GroupBox();
            this.menuMain.SuspendLayout();
            this.groupOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(215, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Choose File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFileToEncrypt
            // 
            this.lblFileToEncrypt.AutoSize = true;
            this.lblFileToEncrypt.Location = new System.Drawing.Point(12, 76);
            this.lblFileToEncrypt.Name = "lblFileToEncrypt";
            this.lblFileToEncrypt.Size = new System.Drawing.Size(0, 13);
            this.lblFileToEncrypt.TabIndex = 1;
            // 
            // btnDoJob
            // 
            this.btnDoJob.Location = new System.Drawing.Point(12, 238);
            this.btnDoJob.Name = "btnDoJob";
            this.btnDoJob.Size = new System.Drawing.Size(215, 23);
            this.btnDoJob.TabIndex = 0;
            this.btnDoJob.Text = "Go";
            this.btnDoJob.UseVisualStyleBackColor = true;
            this.btnDoJob.Click += new System.EventHandler(this.btnDoJob_Click);
            // 
            // txtPassphrase
            // 
            this.txtPassphrase.Location = new System.Drawing.Point(12, 123);
            this.txtPassphrase.Name = "txtPassphrase";
            this.txtPassphrase.Size = new System.Drawing.Size(215, 20);
            this.txtPassphrase.TabIndex = 2;
            // 
            // lblPassphrase
            // 
            this.lblPassphrase.AutoSize = true;
            this.lblPassphrase.Location = new System.Drawing.Point(12, 104);
            this.lblPassphrase.Name = "lblPassphrase";
            this.lblPassphrase.Size = new System.Drawing.Size(65, 13);
            this.lblPassphrase.TabIndex = 3;
            this.lblPassphrase.Text = "Passphrase:";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(239, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SHA256HasherToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // SHA256HasherToolStripMenuItem
            // 
            this.SHA256HasherToolStripMenuItem.Name = "SHA256HasherToolStripMenuItem";
            this.SHA256HasherToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.SHA256HasherToolStripMenuItem.Text = "SHA256 Hasher";
            this.SHA256HasherToolStripMenuItem.Click += new System.EventHandler(this.sha256StripMenuItem_Click);
            // 
            // checkDecrypt
            // 
            this.checkDecrypt.AutoSize = true;
            this.checkDecrypt.Location = new System.Drawing.Point(152, 16);
            this.checkDecrypt.Name = "checkDecrypt";
            this.checkDecrypt.Size = new System.Drawing.Size(63, 17);
            this.checkDecrypt.TabIndex = 6;
            this.checkDecrypt.Text = "Decrypt";
            this.checkDecrypt.UseVisualStyleBackColor = true;
            // 
            // checkEncrypt
            // 
            this.checkEncrypt.AutoSize = true;
            this.checkEncrypt.Checked = true;
            this.checkEncrypt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEncrypt.Location = new System.Drawing.Point(3, 16);
            this.checkEncrypt.Name = "checkEncrypt";
            this.checkEncrypt.Size = new System.Drawing.Size(62, 17);
            this.checkEncrypt.TabIndex = 5;
            this.checkEncrypt.Text = "Encrypt";
            this.checkEncrypt.UseVisualStyleBackColor = true;
            // 
            // groupOption
            // 
            this.groupOption.Controls.Add(this.checkEncrypt);
            this.groupOption.Controls.Add(this.checkDecrypt);
            this.groupOption.Location = new System.Drawing.Point(12, 179);
            this.groupOption.Name = "groupOption";
            this.groupOption.Size = new System.Drawing.Size(215, 42);
            this.groupOption.TabIndex = 7;
            this.groupOption.TabStop = false;
            // 
            // FRM_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 274);
            this.Controls.Add(this.groupOption);
            this.Controls.Add(this.lblPassphrase);
            this.Controls.Add(this.txtPassphrase);
            this.Controls.Add(this.lblFileToEncrypt);
            this.Controls.Add(this.btnDoJob);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "FRM_MAIN";
            this.Text = "Encrypter";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.groupOption.ResumeLayout(false);
            this.groupOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileToEncrypt;
        private System.Windows.Forms.Button btnDoJob;
        private System.Windows.Forms.TextBox txtPassphrase;
        private System.Windows.Forms.Label lblPassphrase;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SHA256HasherToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkDecrypt;
        private System.Windows.Forms.CheckBox checkEncrypt;
        private System.Windows.Forms.GroupBox groupOption;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

