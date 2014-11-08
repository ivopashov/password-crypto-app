using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using RSAEncryptionLib;

namespace RSAEncryptionTester
{
    public partial class MainForm : Form
    {
        RSAEncryption myRsa = new RSAEncryption();
        bool isLoadPrivate = false;
        bool isKeyLoaded = false;
        SetRandomPass pass;

        public MainForm()
        {
            InitializeComponent();
            pass = new SetRandomPass(SetPass);
        }

        private string GetHexString(byte[] byteArray)
        {
            StringBuilder hexString = new StringBuilder(byteArray.Length * 2);
            for (int i = 0; i < byteArray.Length; i++)
                hexString.Append(string.Format("{0:X}", byteArray[i]));
            int x = hexString.Capacity;
            return hexString.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myRsa.Dispose();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string privateKey = rsa.ToXmlString(true);
            File.WriteAllText(Application.StartupPath + "\\PrivateKey.xml", privateKey);
            string publicKey = rsa.ToXmlString(false);
            File.WriteAllText(Application.StartupPath + "\\PublicKey.xml", publicKey);
            MessageBox.Show("The Key pair created successfully at:\n" + Application.StartupPath);
        }

        private void loadPublicKeyBtn_Click(object sender, EventArgs e)
        {
            isLoadPrivate = false;
            LoadKey();
        }

        private void loadPrivateKeyBtn_Click(object sender, EventArgs e)
        {
            isLoadPrivate=true;
            LoadKey();
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            if (isKeyLoaded)
            {
                try
                {
                    byte[] message = Encoding.Default.GetBytes(txtMessage.Text);
                    byte[] encMessage = null;
                    if (isLoadPrivate)
                    {
                        encMessage = myRsa.PrivateEncryption(message);
                    }
                    else
                    {
                        encMessage = myRsa.PublicEncryption(message);
                    }

                    txtEncMsg.Text = Convert.ToBase64String(encMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error occurred while trying to encrypt the data,\nMessage: " + ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("Please load a key");
            }
            
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (isKeyLoaded)
            {
                try
                {
                    byte[] decMessage = Convert.FromBase64String(txtEncMsg.Text);
                    byte[] message = null;

                    if (isLoadPrivate)
                    {
                        message = myRsa.PrivateDecryption(decMessage);
                    }
                    else
                    {
                        message = myRsa.PublicDecryption(decMessage);
                    }


                    string sMsg = Encoding.Default.GetString(message);
                    txtMessage.Text = sMsg;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error occurred while trying to decrypt the data,\nMessage: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please load a key");
            }

        }

        private void LoadKey()
        {
            openKeyFileDialog.InitialDirectory = Application.StartupPath;
            if (openKeyFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (isLoadPrivate)
                    myRsa.LoadPrivateFromXml(openKeyFileDialog.FileName);
                else
                    myRsa.LoadPublicFromXml(openKeyFileDialog.FileName);

                if (!chkShowData.Checked)  
                    return;

                // If he does, Loading the key to .NET RSA class, to show is components in the form:
                RSACryptoServiceProvider localRsa = new RSACryptoServiceProvider();
                localRsa.FromXmlString(File.ReadAllText(openKeyFileDialog.FileName));
                RSAParameters rsaParams = localRsa.ExportParameters(isLoadPrivate);
                ClearInputFields();
                txtExponent.Text = GetHexString(rsaParams.Exponent);
                txtModulus.Text = GetHexString(rsaParams.Modulus);
                if (isLoadPrivate)
                    txtD.Text = GetHexString(rsaParams.D);  // This parameter is in private key only
                isKeyLoaded = true;
                // Clearing the RSA instance
                localRsa.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to load a Key,\nMessage: " + ex.Message);
            }
        }

        private void ClearInputFields()
        {
            txtExponent.Text = "";
            txtModulus.Text = "";
            txtD.Text="";
        }

        private void enableFieldsBtn_Click(object sender, EventArgs e)
        {
            txtExponent.Enabled = true;
            txtModulus.Enabled = true;
            txtD.Enabled = true;
        }

        private void generateStringBtn_Click(object sender, EventArgs e)
        {
            var randomKeyGenerator=new RandomKeyGenerator(pass);
            randomKeyGenerator.Show();
        }

        public void SetPass(string pass)
        {
            txtMessage.Text = pass;
        }
    }
}
