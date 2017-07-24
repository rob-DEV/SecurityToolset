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
    public partial class FRM_SHA256_HASHER : Form
    {
        private String filePath = String.Empty;

        public FRM_SHA256_HASHER()
        {
            InitializeComponent();
            this.CenterToParent();
        }
        private void OpenFile()
        {
            OpenFileDialog fileDiag = new OpenFileDialog();

            if (fileDiag.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDiag.FileName;
                lblFileToEncrypt.Text = fileDiag.FileName;

            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnComputeHash_Click(object sender, EventArgs e)
        {
            txtHash.Text = Security.Security.GenerateSHA256(filePath);
        }
    }
}
