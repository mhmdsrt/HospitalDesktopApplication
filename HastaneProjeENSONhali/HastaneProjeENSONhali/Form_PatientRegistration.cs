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
    public partial class Form_PatientRegistration : Form
    {
        public Form_PatientRegistration()
        {
            InitializeComponent();
        }
        Sqlconn connect = new Sqlconn();
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //Önce kayıt var mı? Kontrol edelim.Mevcut ise hata verdirelim.
            SqlCommand cmdCheckyRegis =new SqlCommand("Select PatientTC from Table_Patients Where PatientTC=@p1",
                connect.connect());
            cmdCheckyRegis.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            SqlDataReader drCheckRegis = cmdCheckyRegis.ExecuteReader();

            if (drCheckRegis.Read())
            {
                MessageBox.Show("Such a record already exists", "Registration is available",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmdRegis = new SqlCommand("INSERT INTO Table_Patients(PatientFirstName,PatientSurname,PatientTC,PatientPhone,PatientPassword,PatientGender) " +
                "VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", connect.connect());

                cmdRegis.Parameters.AddWithValue("@p1", txtFistName.Text);
                cmdRegis.Parameters.AddWithValue("@p2", txtSurName.Text);
                cmdRegis.Parameters.AddWithValue("@p3", maskedTextBoxTC.Text);
                cmdRegis.Parameters.AddWithValue("@p4", maskedTextBoxPhone.Text);
                cmdRegis.Parameters.AddWithValue("@p5", txtPassword.Text);

                if (radioBtnMan.Checked == true)
                {
                    cmdRegis.Parameters.AddWithValue("@p6", "Man");

                }
                else if (radioBtnWomen.Checked == true)
                {
                    cmdRegis.Parameters.AddWithValue("@p6", "Women");
                }

                cmdRegis.ExecuteNonQuery();
                MessageBox.Show("Successful!", "Registration is Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            connect.connect().Close();

        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Form_PatientEntry frm = new Form_PatientEntry();
            this.Hide();
            frm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFistName.Text = "";
            txtSurName.Text = "";
            maskedTextBoxTC.Text = "";
            maskedTextBoxPhone.Text = "";
            txtPassword.Text = "";
            radioBtnMan.Checked = false;
            radioBtnWomen.Checked = false;
        }
    }
}
