namespace HastaneProjeENSONhali
{
    partial class Form_DoctorDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DoctorDetail));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnComeBack = new System.Windows.Forms.Button();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblTC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxComplaint = new System.Windows.Forms.RichTextBox();
            this.btnViewAnnoun = new System.Windows.Forms.Button();
            this.dataGridViewAppoint = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppoint)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Controls.Add(this.btnComeBack);
            this.groupBox1.Controls.Add(this.lblSurname);
            this.groupBox1.Controls.Add(this.lblFirstName);
            this.groupBox1.Controls.Add(this.lblTC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Constantia", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doctor Information";
            // 
            // btnComeBack
            // 
            this.btnComeBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnComeBack.BackgroundImage")));
            this.btnComeBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnComeBack.Location = new System.Drawing.Point(12, 33);
            this.btnComeBack.Name = "btnComeBack";
            this.btnComeBack.Size = new System.Drawing.Size(45, 43);
            this.btnComeBack.TabIndex = 29;
            this.btnComeBack.UseVisualStyleBackColor = true;
            this.btnComeBack.Click += new System.EventHandler(this.btnComeBack_Click);
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSurname.Location = new System.Drawing.Point(237, 105);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(64, 24);
            this.lblSurname.TabIndex = 28;
            this.lblSurname.Text = "NULL";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFirstName.Location = new System.Drawing.Point(237, 72);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(64, 24);
            this.lblFirstName.TabIndex = 27;
            this.lblFirstName.Text = "NULL";
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTC.Location = new System.Drawing.Point(237, 42);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(64, 24);
            this.lblTC.TabIndex = 26;
            this.lblTC.Text = "NULL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(113, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 28);
            this.label7.TabIndex = 25;
            this.label7.Text = "SurName:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(98, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 28);
            this.label6.TabIndex = 24;
            this.label6.Text = "FirstName:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(183, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 28);
            this.label5.TabIndex = 23;
            this.label5.Text = "TC:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox2.Controls.Add(this.richTextBoxComplaint);
            this.groupBox2.Font = new System.Drawing.Font("Constantia", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(0, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 546);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Appointment Detail";
            // 
            // richTextBoxComplaint
            // 
            this.richTextBoxComplaint.Location = new System.Drawing.Point(26, 54);
            this.richTextBoxComplaint.Name = "richTextBoxComplaint";
            this.richTextBoxComplaint.Size = new System.Drawing.Size(374, 451);
            this.richTextBoxComplaint.TabIndex = 0;
            this.richTextBoxComplaint.Text = "";
            // 
            // btnViewAnnoun
            // 
            this.btnViewAnnoun.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnViewAnnoun.Location = new System.Drawing.Point(103, 705);
            this.btnViewAnnoun.Name = "btnViewAnnoun";
            this.btnViewAnnoun.Size = new System.Drawing.Size(238, 39);
            this.btnViewAnnoun.TabIndex = 24;
            this.btnViewAnnoun.Text = "Announcements";
            this.btnViewAnnoun.UseVisualStyleBackColor = true;
            this.btnViewAnnoun.Click += new System.EventHandler(this.btnViewAnnoun_Click);
            // 
            // dataGridViewAppoint
            // 
            this.dataGridViewAppoint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAppoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppoint.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewAppoint.Name = "dataGridViewAppoint";
            this.dataGridViewAppoint.RowHeadersWidth = 51;
            this.dataGridViewAppoint.RowTemplate.Height = 24;
            this.dataGridViewAppoint.Size = new System.Drawing.Size(1313, 711);
            this.dataGridViewAppoint.TabIndex = 25;
            this.dataGridViewAppoint.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAppoint_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewAppoint);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(439, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1325, 741);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Appointments";
            // 
            // Form_DoctorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1776, 756);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnViewAnnoun);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DoctorDetail";
            this.Text = "Doctor Detail";
            this.Load += new System.EventHandler(this.Form_DoctorDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppoint)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnComeBack;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxComplaint;
        private System.Windows.Forms.Button btnViewAnnoun;
        private System.Windows.Forms.DataGridView dataGridViewAppoint;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}