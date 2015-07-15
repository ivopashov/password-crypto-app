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
        string passwordsFile = "passwords.txt";

        public MainForm()
        {
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

        private void decrypt()
        {
            if (isPrivateKeyLoaded)
            {
                try
                {
                    byte[] decMessage = Convert.FromBase64String(viewedEntry.EncryptedPassword);
                    byte[] message = null;
                    message = myRsa.PrivateDecryption(decMessage);
                    string sMsg = Encoding.Default.GetString(message);
                    textBox7.Text = sMsg;
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

        private void generateStringBtn_Click(object sender, EventArgs e)
        {
            var randomKeyGenerator = new RandomKeyGenerator(pass);
            randomKeyGenerator.Show();
        }

        public void SetPass(string pass)
        {
            txtMessage.Text = pass;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (isPublicKeyLoaded)
            {
                try
                {
                    byte[] message = Encoding.Default.GetBytes(txtMessage.Text);
                    byte[] encMessage = null;
                    encMessage = myRsa.PublicEncryption(message);
                    newlyCreatedEntry.EncryptedPassword = Convert.ToBase64String(encMessage);
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

            viewedEntry = Entries.Where(p => p.Name.Equals(selectedName)).SingleOrDefault();
            textBox5.Text = viewedEntry.Category;
            textBox6.Text = viewedEntry.Name;
            textBox4.Text = viewedEntry.OtherInfo;
            decrypt();
            NullifyDropDown(comboBox1);
            comboBox1.Items.AddRange(Entries.Select(a => a.Category).Distinct().ToArray());
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
            Entries[oldEntryIndex].Name = textBox6.Text;
            Entries[oldEntryIndex].OtherInfo = textBox4.Text;
            Entries[oldEntryIndex].Category = textBox5.Text;
            UpdateOrAddEntry();
        }
    }
}
