namespace RSAEncryptionTester
{
    partial class MainForm
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
            this.openKeyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExponent = new System.Windows.Forms.TextBox();
            this.txtModulus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEncMsg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkShowData = new System.Windows.Forms.CheckBox();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.loadPublicKeyBtn = new System.Windows.Forms.Button();
            this.loadPrivateKeyBtn = new System.Windows.Forms.Button();
            this.enableFieldsBtn = new System.Windows.Forms.Button();
            this.generateStringBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openKeyFileDialog
            // 
            this.openKeyFileDialog.Filter = "Key File|*.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Exponent: ";
            // 
            // txtExponent
            // 
            this.txtExponent.BackColor = System.Drawing.SystemColors.Window;
            this.txtExponent.Enabled = false;
            this.txtExponent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtExponent.Location = new System.Drawing.Point(99, 100);
            this.txtExponent.Name = "txtExponent";
            this.txtExponent.ReadOnly = true;
            this.txtExponent.Size = new System.Drawing.Size(285, 22);
            this.txtExponent.TabIndex = 2;
            // 
            // txtModulus
            // 
            this.txtModulus.BackColor = System.Drawing.SystemColors.Window;
            this.txtModulus.Enabled = false;
            this.txtModulus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtModulus.Location = new System.Drawing.Point(99, 128);
            this.txtModulus.Multiline = true;
            this.txtModulus.Name = "txtModulus";
            this.txtModulus.ReadOnly = true;
            this.txtModulus.Size = new System.Drawing.Size(675, 60);
            this.txtModulus.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Modulus: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(12, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Message: ";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMessage.Location = new System.Drawing.Point(139, 326);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(635, 22);
            this.txtMessage.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(12, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Encrypted Message: ";
            // 
            // txtEncMsg
            // 
            this.txtEncMsg.BackColor = System.Drawing.SystemColors.Window;
            this.txtEncMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtEncMsg.Location = new System.Drawing.Point(139, 354);
            this.txtEncMsg.Multiline = true;
            this.txtEncMsg.Name = "txtEncMsg";
            this.txtEncMsg.Size = new System.Drawing.Size(635, 60);
            this.txtEncMsg.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(12, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 28);
            this.label6.TabIndex = 8;
            this.label6.Text = "D (Private\r\nExponent):";
            // 
            // txtD
            // 
            this.txtD.BackColor = System.Drawing.SystemColors.Window;
            this.txtD.Enabled = false;
            this.txtD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtD.Location = new System.Drawing.Point(99, 194);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.ReadOnly = true;
            this.txtD.Size = new System.Drawing.Size(675, 60);
            this.txtD.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(12, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "Encryption / Decryption";
            // 
            // chkShowData
            // 
            this.chkShowData.AutoSize = true;
            this.chkShowData.Checked = true;
            this.chkShowData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkShowData.Location = new System.Drawing.Point(99, 75);
            this.chkShowData.Name = "chkShowData";
            this.chkShowData.Size = new System.Drawing.Size(57, 18);
            this.chkShowData.TabIndex = 11;
            this.chkShowData.Text = "Show";
            this.chkShowData.UseVisualStyleBackColor = true;
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(474, 284);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(75, 23);
            this.encryptBtn.TabIndex = 12;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(565, 284);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(75, 23);
            this.decryptBtn.TabIndex = 13;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(328, 38);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 14;
            this.createBtn.Text = "Create Keys";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // loadPublicKeyBtn
            // 
            this.loadPublicKeyBtn.Location = new System.Drawing.Point(423, 37);
            this.loadPublicKeyBtn.Name = "loadPublicKeyBtn";
            this.loadPublicKeyBtn.Size = new System.Drawing.Size(96, 23);
            this.loadPublicKeyBtn.TabIndex = 15;
            this.loadPublicKeyBtn.Text = "Load Public Key";
            this.loadPublicKeyBtn.UseVisualStyleBackColor = true;
            this.loadPublicKeyBtn.Click += new System.EventHandler(this.loadPublicKeyBtn_Click);
            // 
            // loadPrivateKeyBtn
            // 
            this.loadPrivateKeyBtn.Location = new System.Drawing.Point(539, 37);
            this.loadPrivateKeyBtn.Name = "loadPrivateKeyBtn";
            this.loadPrivateKeyBtn.Size = new System.Drawing.Size(100, 23);
            this.loadPrivateKeyBtn.TabIndex = 16;
            this.loadPrivateKeyBtn.Text = "Load Private Key";
            this.loadPrivateKeyBtn.UseVisualStyleBackColor = true;
            this.loadPrivateKeyBtn.Click += new System.EventHandler(this.loadPrivateKeyBtn_Click);
            // 
            // enableFieldsBtn
            // 
            this.enableFieldsBtn.Location = new System.Drawing.Point(390, 98);
            this.enableFieldsBtn.Name = "enableFieldsBtn";
            this.enableFieldsBtn.Size = new System.Drawing.Size(90, 23);
            this.enableFieldsBtn.TabIndex = 17;
            this.enableFieldsBtn.Text = "Enable Fields";
            this.enableFieldsBtn.UseVisualStyleBackColor = true;
            this.enableFieldsBtn.Click += new System.EventHandler(this.enableFieldsBtn_Click);
            // 
            // generateStringBtn
            // 
            this.generateStringBtn.Location = new System.Drawing.Point(661, 284);
            this.generateStringBtn.Name = "generateStringBtn";
            this.generateStringBtn.Size = new System.Drawing.Size(113, 23);
            this.generateStringBtn.TabIndex = 18;
            this.generateStringBtn.Text = "Generate Password";
            this.generateStringBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.generateStringBtn.UseVisualStyleBackColor = true;
            this.generateStringBtn.Click += new System.EventHandler(this.generateStringBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 448);
            this.Controls.Add(this.generateStringBtn);
            this.Controls.Add(this.enableFieldsBtn);
            this.Controls.Add(this.loadPrivateKeyBtn);
            this.Controls.Add(this.loadPublicKeyBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.chkShowData);
            this.Controls.Add(this.txtEncMsg);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtModulus);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtExponent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "RSA Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openKeyFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExponent;
        private System.Windows.Forms.TextBox txtModulus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEncMsg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkShowData;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button loadPublicKeyBtn;
        private System.Windows.Forms.Button loadPrivateKeyBtn;
        private System.Windows.Forms.Button enableFieldsBtn;
        private System.Windows.Forms.Button generateStringBtn;
    }
}

