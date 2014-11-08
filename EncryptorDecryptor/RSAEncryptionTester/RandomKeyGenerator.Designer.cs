namespace RSAEncryptionTester
{
    partial class RandomKeyGenerator
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
            this.generateBtn = new System.Windows.Forms.Button();
            this.resultTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.allowedCharsTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.maxSymbolsTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keepBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(249, 137);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(75, 52);
            this.generateBtn.TabIndex = 0;
            this.generateBtn.Text = "Generate Random String";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // resultTxt
            // 
            this.resultTxt.Location = new System.Drawing.Point(12, 195);
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(231, 20);
            this.resultTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Result";
            // 
            // allowedCharsTxt
            // 
            this.allowedCharsTxt.Location = new System.Drawing.Point(12, 61);
            this.allowedCharsTxt.Name = "allowedCharsTxt";
            this.allowedCharsTxt.Size = new System.Drawing.Size(231, 20);
            this.allowedCharsTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Allowed Chars - You can modify them";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 122);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(141, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // maxSymbolsTxt
            // 
            this.maxSymbolsTxt.Enabled = false;
            this.maxSymbolsTxt.Location = new System.Drawing.Point(163, 122);
            this.maxSymbolsTxt.Name = "maxSymbolsTxt";
            this.maxSymbolsTxt.Size = new System.Drawing.Size(64, 20);
            this.maxSymbolsTxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number Of Symbols";
            // 
            // keepBtn
            // 
            this.keepBtn.Location = new System.Drawing.Point(250, 191);
            this.keepBtn.Name = "keepBtn";
            this.keepBtn.Size = new System.Drawing.Size(75, 23);
            this.keepBtn.TabIndex = 8;
            this.keepBtn.Text = "Keep";
            this.keepBtn.UseVisualStyleBackColor = true;
            this.keepBtn.Click += new System.EventHandler(this.keepBtn_Click);
            // 
            // RandomKeyGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 287);
            this.Controls.Add(this.keepBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxSymbolsTxt);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.allowedCharsTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultTxt);
            this.Controls.Add(this.generateBtn);
            this.Name = "RandomKeyGenerator";
            this.Text = "RandomKeyGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.TextBox resultTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox allowedCharsTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox maxSymbolsTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button keepBtn;
    }
}