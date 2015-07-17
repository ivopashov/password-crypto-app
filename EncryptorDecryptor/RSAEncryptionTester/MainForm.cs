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
using System.Web;
using System.Web.Script.Serialization;
using System.Linq;

namespace RSAEncryptionTester
{
    public partial class MainForm : Form
    {
        RSAEncryption myRsa = new RSAEncryption();
        bool isPublicKeyLoaded = false;
        bool isPrivateKeyLoaded = false;
        SetRandomPass pass;
        List<Entry> Entries;
        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
        Entry newlyCreatedEntry = new Entry();
        Entry viewedEntry = new Entry();
        string passwordsFile = string.Empty;

        public MainForm(string passwordFilePath)
        {
            passwordsFile = passwordFilePath;
            InitializeComponent();
            pass = new SetRandomPass(SetPass);
            InitializePasswords();
            InitializeComboBoxes();
        }

        public void InitializeComboBoxes()
        {
            NullifyDropDown(comboBox1);
            NullifyDropDown(comboBox2);
            if (Entries.Any())
            {
                comboBox2.Items.AddRange(Entries.Select(a => a.Name).ToArray());
                comboBox1.Items.AddRange(Entries.Select(a => a.Category).Distinct().ToArray());
            }
        }

        private void InitializePasswords()
        {
            var textentries = File.ReadAllText("passwords.txt");
            Entries = new List<Entry>();
            Entries = json_serializer.Deserialize<List<Entry>>(textentries) ?? Entries;
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
            openKeyFileDialog.InitialDirectory = Application.StartupPath;
            if (openKeyFileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                myRsa.LoadPublicFromXml(openKeyFileDialog.FileName);
                isPublicKeyLoaded = true;
                label12.Text = "Public key:" + openKeyFileDialog.FileName.Split(new char[] { '\\' }).Last() + " is loaded.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to load a Key,\nMessage: " + ex.Message);
            }

        }

        private void loadPrivateKeyBtn_Click(object sender, EventArgs e)
        {
            openKeyFileDialog.InitialDirectory = Application.StartupPath;
            if (openKeyFileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                myRsa.LoadPrivateFromXml(openKeyFileDialog.FileName);
                isPrivateKeyLoaded = true;
                label13.Text = "Private key:" + openKeyFileDialog.FileName.Split(new char[] { '\\' }).Last() + " is loaded.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to load a Key,\nMessage: " + ex.Message);
            }
        }

        private string decrypt(string pass)
        {
            try
            {
                byte[] decMessage = Convert.FromBase64String(pass);
                byte[] message = null;
                message = myRsa.PrivateDecryption(decMessage);
                string sMsg = Encoding.Default.GetString(message);
                return sMsg;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to decrypt the data,\nMessage: " + ex.Message);
                throw;
            }
        }

        private void generateStringBtn_Click(object sender, EventArgs e)
        {
            var randomKeyGenerator = new RandomKeyGenerator(pass);
            randomKeyGenerator.Show();
        }

        public void SetPass(string pass)
        {
            txtMessage.Text = pass;
        }

        private string Encrypt(string pass)
        {
            try
            {
                byte[] message = Encoding.Default.GetBytes(pass);
                byte[] encMessage = null;
                encMessage = myRsa.PublicEncryption(message);
                return Convert.ToBase64String(encMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to encrypt the data,\nMessage: " + ex.Message);
                throw;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (isPublicKeyLoaded)
            {
                newlyCreatedEntry.EncryptedPassword = Encrypt(txtMessage.Text);
                newlyCreatedEntry.Name = textBox1.Text;
                newlyCreatedEntry.Category = textBox2.Text;
                newlyCreatedEntry.OtherInfo = textBox3.Text;
                if (!Entries.Contains(newlyCreatedEntry))
                {
                    Entries.Add(newlyCreatedEntry);
                    newlyCreatedEntry = new Entry();
                }
                txtMessage.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;

                UpdateOrAddEntry();
            }
            else
            {
                MessageBox.Show("Please load a public key");
            }
        }

        private void UpdateOrAddEntry()
        {
            File.WriteAllText(passwordsFile, String.Empty);
            File.WriteAllText(passwordsFile, json_serializer.Serialize(Entries));
            InitializePasswords();
            InitializeComboBoxes();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var selectedName = (string)comboBox.SelectedItem;
            if (isPrivateKeyLoaded)
            {
                viewedEntry = Entries.Where(p => p.Name.Equals(selectedName)).SingleOrDefault();
                textBox5.Text = viewedEntry.Category;
                textBox6.Text = viewedEntry.Name;
                textBox4.Text = viewedEntry.OtherInfo;
                textBox7.Text = decrypt(viewedEntry.EncryptedPassword);
                NullifyDropDown(comboBox1);
                comboBox1.Items.AddRange(Entries.Select(a => a.Category).Distinct().ToArray());
            }
            else
            {
                MessageBox.Show("Please load a private key");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var selectedCat = (string)comboBox.SelectedItem;

            NullifyDropDown(comboBox2);
            var filteredNames = Entries.Where(t => t.Category.Equals(selectedCat)).Select(a => a.Name).ToArray();
            comboBox2.Items.AddRange(filteredNames);
        }

        private void NullifyDropDown(ComboBox cb)
        {
            cb.Items.Clear();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var oldEntryIndex = Entries.IndexOf(viewedEntry);

            var decryptedPass = decrypt(Entries[oldEntryIndex].EncryptedPassword);

            if (!decryptedPass.Equals(textBox7.Text))
            {
                if (isPublicKeyLoaded)
                {
                    Entries[oldEntryIndex].Name = textBox6.Text;
                    Entries[oldEntryIndex].OtherInfo = textBox4.Text;
                    Entries[oldEntryIndex].Category = textBox5.Text;
                    Entries[oldEntryIndex].EncryptedPassword = Encrypt(textBox7.Text);
                    UpdateOrAddEntry();
                }
                else
                {
                    MessageBox.Show("Please load a public key");
                }
            }
            else
            {
                Entries[oldEntryIndex].Name = textBox6.Text;
                Entries[oldEntryIndex].OtherInfo = textBox4.Text;
                Entries[oldEntryIndex].Category = textBox5.Text;
                UpdateOrAddEntry();
            }


        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Dispose(true);
            Application.Exit();
        }
    }
}
