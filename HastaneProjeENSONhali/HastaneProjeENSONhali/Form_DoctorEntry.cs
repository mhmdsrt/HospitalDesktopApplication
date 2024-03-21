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
    public partial class Form_DoctorEntry : Form
    {
        public Form_DoctorEntry()
        {
            InitializeComponent();
        }
        Sqlconn connect = new Sqlconn();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmdLogin = new SqlCommand("Select DoctorTC,DoctorPassword From Table_Doctors Where DoctorTC=@p1 and " +
                "DoctorPassword=@p2", connect.connect());
            cmdLogin.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            cmdLogin.Parameters.AddWithValue("@p2", txtBoxPasswd.Text);
            SqlDataReader drLogin = cmdLogin.ExecuteReader();
            if (drLogin.Read())
            {
                Form_DoctorDetail frm = new Form_DoctorDetail();
                this.Hide();
                frm.tc = Convert.ToDouble(maskedTextBoxTC.Text);
                frm.Show();
            }
            else
            {
                MessageBox.Show("You entered the wrong TC or PASSWORD !!", "İncorrect Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connect.connect().Close();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Form_Base frm = new Form_Base();
            this.Hide();
            frm.Show();
        }
    }
}
