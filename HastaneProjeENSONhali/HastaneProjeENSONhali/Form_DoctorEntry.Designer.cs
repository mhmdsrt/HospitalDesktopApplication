namespace HastaneProjeENSONhali
{
    partial class Form_DoctorEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DoctorEntry));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnComeBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtBoxPasswd = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTC = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.btnComeBack);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1501, 116);
            this.panel1.TabIndex = 4;
            // 
            // btnComeBack
            // 
            this.btnComeBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnComeBack.BackgroundImage")));
            this.btnComeBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnComeBack.Location = new System.Drawing.Point(23, 31);
            this.btnComeBack.Name = "btnComeBack";
            this.btnComeBack.Size = new System.Drawing.Size(47, 43);
            this.btnComeBack.TabIndex = 6;
            this.btnComeBack.UseVisualStyleBackColor = true;
            this.btnComeBack.Click += new System.EventHandler(this.btnComeBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(522, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(534, 97);
            this.label3.TabIndex = 4;
            this.label3.Text = "Doctor Entry";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Constantia", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.Location = new System.Drawing.Point(645, 472);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(353, 71);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtBoxPasswd
            // 
            this.txtBoxPasswd.Font = new System.Drawing.Font("Mongolian Baiti", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPasswd.Location = new System.Drawing.Point(556, 357);
            this.txtBoxPasswd.Name = "txtBoxPasswd";
            this.txtBoxPasswd.Size = new System.Drawing.Size(548, 57);
            this.txtBoxPasswd.TabIndex = 8;
            this.txtBoxPasswd.UseSystemPasswordChar = true;
            // 
            // maskedTextBoxTC
            // 
            this.maskedTextBoxTC.Font = new System.Drawing.Font("Mongolian Baiti", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxTC.Location = new System.Drawing.Point(556, 265);
            this.maskedTextBoxTC.Mask = "00000000000";
            this.maskedTextBoxTC.Name = "maskedTextBoxTC";
            this.maskedTextBoxTC.Size = new System.Drawing.Size(548, 57);
            this.maskedTextBoxTC.TabIndex = 11;
            this.maskedTextBoxTC.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(164, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 73);
            this.label2.TabIndex = 10;
            this.label2.Text = "PASSWORD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(434, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 73);
            this.label1.TabIndex = 9;
            this.label1.Text = "TC:";
            // 
            // Form_DoctorEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1499, 704);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtBoxPasswd);
            this.Controls.Add(this.maskedTextBoxTC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form_DoctorEntry";
            this.Text = "Doctor Entry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnComeBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtBoxPasswd;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}