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
using System.Runtime.Remoting.Contexts;

namespace HastaneProjeENSONhali
{
    public partial class Form_PatientInformationUpdate : Form
    {
        public Form_PatientInformationUpdate()
        {
            InitializeComponent();
        }
        Sqlconn connect =new Sqlconn();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Güncellenecek olan kayıt var mı? Kontrol edelim.
            SqlCommand cmdCheckRegis =new SqlCommand("Select PatientTC from Table_Patients Where PatientTC="+maskedTextBoxTC.Text
                ,connect.connect());

            SqlDataReader drCheckRegis = cmdCheckRegis.ExecuteReader();
            if (drCheckRegis.Read())
            {
                connect.connect().Close();
                SqlCommand cmdUpdate = new SqlCommand("Update Table_Patients set PatientFirstName=@p1,PatientSurName=@p2,PatientTC=@p3," +
                "PatientPhone=@p4,PatientPassword=@p5,PatientGender=@p6 Where PatientTC=" + maskedTextBoxTC.Text, connect.connect());
                cmdUpdate.Parameters.AddWithValue("@p1", txtFirstName.Text);
                cmdUpdate.Parameters.AddWithValue("@p2", txtSurName.Text);
                cmdUpdate.Parameters.AddWithValue("@p3", maskedTextBoxTC.Text);
                cmdUpdate.Parameters.AddWithValue("@p4", maskedTextBoxPhone.Text);
                cmdUpdate.Parameters.AddWithValue("@p5", txtPasswd.Text);

                if (radioBtnMan.Checked == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@p6", "Man");

                }
                else if (radioBtnWomen.Checked == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@p6", "Women");

                }
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Update was successful!","Successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Patient record could not be found","Not Registered",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            //Kutucukları temizle.
            maskedTextBoxTC.Text = "";
            txtFirstName.Text = "";
            txtSurName.Text = "";
            txtPasswd.Text = "";
            maskedTextBoxPhone.Text = "";
            radioBtnMan.Checked = false;
            radioBtnWomen.Checked = false;
        }

        private void maskedTextBoxTC_TextChanged(object sender, EventArgs e)
        {
            //MaskedTextBoxdaki kutucuğa girilen TC ye göre diğer kutucukları doldur.
            SqlCommand cmdGetInformation = new SqlCommand("Select * From Table_Patients Where PatientTC=@p1", connect.connect());
            cmdGetInformation.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            SqlDataReader drGetInformation = cmdGetInformation.ExecuteReader();
            while (drGetInformation.Read())
            {
                txtFirstName.Text = drGetInformation[0].ToString();
                txtSurName.Text = drGetInformation[1].ToString();
                maskedTextBoxPhone.Text = drGetInformation[3].ToString();
                txtPasswd.Text = drGetInformation[4].ToString();

                if (drGetInformation[5].ToString() == "Man")
                {
                    radioBtnMan.Checked = true;
                }
                else if (drGetInformation[5].ToString() == "Women")
                {
                    radioBtnWomen.Checked = true;
                }

            }
            connect.connect().Close();
        }
    }
}
