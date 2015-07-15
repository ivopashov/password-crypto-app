using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RSAEncryptionTester
{
    public delegate void SetRandomPass(string pass);

    public partial class RandomKeyGenerator : Form
    {
        SetRandomPass _pass;

        public RandomKeyGenerator(SetRandomPass pass)
        {
            InitializeComponent();
            _pass = pass;
            allowedCharsTxt.Text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890$&*_()";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            maxSymbolsTxt.Text = trackBar1.Value.ToString();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            var chars = new char[allowedCharsTxt.Text.Length];
            chars =
            allowedCharsTxt.Text.ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[trackBar1.Value];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(trackBar1.Value);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            resultTxt.Text=result.ToString();
        }

        private void keepBtn_Click(object sender, EventArgs e)
        {
            _pass(resultTxt.Text);
            this.Dispose();
        }


    }
}
