using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FileNameInputBox : Form
    {
        public string newFileName;
        public string oldFileName;

        public FileNameInputBox()
        {
            InitializeComponent();
        }

        private void FileNameInputBox_Load(object sender, EventArgs e)
        {
            fileNameText.Text= oldFileName;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            newFileName = fileNameText.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
