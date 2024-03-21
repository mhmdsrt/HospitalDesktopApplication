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
    public partial class Form_SecretaryEntry : Form
    {
        public Form_SecretaryEntry()
        {
            InitializeComponent();
        }
        Sqlconn connect = new Sqlconn();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Table_Secretarys Where SecretaryTC=@p1 and SecretaryPassword=@p2",
                connect.connect());
            cmd.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            cmd.Parameters.AddWithValue("@p2", txtBoxPasswd.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form_SecretaryDetail frm = new Form_SecretaryDetail();
                this.Hide();
                frm.TC = Convert.ToDouble(maskedTextBoxTC.Text);
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
