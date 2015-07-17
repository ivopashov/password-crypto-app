using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSAEncryptionTester
{

    public partial class SetPasswordFilePath : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public SetPasswordFilePath()
        {
            InitializeComponent();
        }

        private void ChoosePassFilePathBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                var mainForm = new MainForm(openFileDialog1.FileName);
                mainForm.Show();
                this.Hide();
            }
        }
    }
}
