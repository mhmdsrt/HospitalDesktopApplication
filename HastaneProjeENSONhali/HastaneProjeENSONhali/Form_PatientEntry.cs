using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneProjeENSONhali
{
    public partial class Form_PatientEntry : Form
    {
        public Form_PatientEntry()
        {
            InitializeComponent();
        }
        Sqlconn connect =new Sqlconn();

        private void linkLblRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_PatientRegistration form = new Form_PatientRegistration();
            form.Show();
            this.Hide();
        }

        private void linkLblUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_PatientInformationUpdate form = new Form_PatientInformationUpdate();
            form.Show();
            this.Hide();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Form_Base form = new Form_Base();
            form.Show();
            this.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_Patients where PatientTC=@p1 and PatientPassWord=@p2", connect.connect());
            cmd.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            cmd.Parameters.AddWithValue("@p2",txtBoxPasswd.Text);
            SqlDataReader dr=cmd.ExecuteReader();
            if(dr.Read())
            {
                Form_PatientDetail frm=new Form_PatientDetail();
                this.Hide();
                frm.tc=Convert.ToDouble(maskedTextBoxTC.Text);
                frm.Show();
            }
            else
            {
                MessageBox.Show("You entered the wrong TC or PASSWORD !!", "İncorrect Entry",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            connect.connect().Close();

        }

   
    }
}
