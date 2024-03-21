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
    public partial class Form_DoctorEdit : Form
    {
        public Form_DoctorEdit()
        {
            InitializeComponent();
        }
        Sqlconn connect = new Sqlconn();
        public double secretaryTC;
        private void btnComeBack_Click(object sender, EventArgs e)
        {
            //SecretaryDetail formuna geçildiğinde ,sekreter bilgileri tekrar yüklenebilmesi için.
            Form_SecretaryDetail frm = new Form_SecretaryDetail();
            this.Hide();
            frm.TC = secretaryTC;
            frm.Show();
        }

        private void Form_DoctorEdit_Load(object sender, EventArgs e)
        {          
            //Doktorları DategridViewe çekme.
            DataTable dtDoctor = new DataTable();
            SqlDataAdapter daDoctor = new SqlDataAdapter("Select * From Table_Doctors", connect.connect());
            daDoctor.Fill(dtDoctor);
            dataGridViewDoctor.DataSource = dtDoctor;

            //Branşları Comboboxa çekme.
            SqlCommand cmdGetBranch = new SqlCommand("Select BranchName From Table_Branchs", connect.connect());
            SqlDataReader drGetBranch = cmdGetBranch.ExecuteReader();
            while (drGetBranch.Read())
            {
                comboBoxBranch.Items.Add(drGetBranch[0].ToString());
            }
            connect.connect().Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Kayıt var mı ? Kontrol edelim,eğer varsa kayıt ekleme başarısız olup hata mesajı verelim.
            SqlCommand cmdCheckDoctor = new SqlCommand("Select DoctorTC From Table_Doctors Where DoctorTC=@p1", connect.connect());
            cmdCheckDoctor.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            SqlDataReader drCheckDoctor = cmdCheckDoctor.ExecuteReader();
            if (drCheckDoctor.Read())
            {
                MessageBox.Show("The registration is already available", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                connect.connect().Close();
                SqlCommand cmdCreateDoctor = new SqlCommand("Insert Into Table_Doctors VALUES (@p1,@p2,@p3,@p4,@p5)", connect.connect());
                cmdCreateDoctor.Parameters.AddWithValue("@p1", txtFirstName.Text);
                cmdCreateDoctor.Parameters.AddWithValue("@p2", txtSurName.Text);
                cmdCreateDoctor.Parameters.AddWithValue("@p3", comboBoxBranch.Text);
                cmdCreateDoctor.Parameters.AddWithValue("@p4", maskedTextBoxTC.Text);
                cmdCreateDoctor.Parameters.AddWithValue("@p5", txtPassword.Text);
                cmdCreateDoctor.ExecuteNonQuery();
                connect.connect().Close();
                MessageBox.Show("Successful!", "The doctor was created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kayıt eklendikten sonra DataGridViewi yenileyelim.
                MyRefreshDataGridView refreshData = new MyRefreshDataGridView("Table_Doctors",dataGridViewDoctor);
                
             

            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //kutucukları temizleyelim.
            txtFirstName.Text = "";
            txtSurName.Text = "";
            comboBoxBranch.Text = "";
            txtPassword.Text = "";
            maskedTextBoxTC.Text = "";
        }

        private void dataGridViewDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewin herhangibir hücresine tıklandığı zaman tıklanan satırdaki bilgileri kutucuklara gir.
            int index = dataGridViewDoctor.SelectedCells[0].RowIndex;
            txtFirstName.Text = dataGridViewDoctor.Rows[index].Cells[0].Value.ToString();
            txtSurName.Text = dataGridViewDoctor.Rows[index].Cells[1].Value.ToString();
            comboBoxBranch.Text = dataGridViewDoctor.Rows[index].Cells[2].Value.ToString();
            maskedTextBoxTC.Text = dataGridViewDoctor.Rows[index].Cells[3].Value.ToString();
            txtPassword.Text = dataGridViewDoctor.Rows[index].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Güncellenecek veriyi önce var mı? Diye kontrol edelim.
            SqlCommand cmdCheckRegis = new SqlCommand("Select DoctorTC From Table_Doctors Where DoctorTC=@p1", connect.connect());
            cmdCheckRegis.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            SqlDataReader drCheckRegis = cmdCheckRegis.ExecuteReader();
            if (drCheckRegis.Read())
            {
                connect.connect().Close();
                SqlCommand cmdUpdateDoctor = new SqlCommand("Update Table_Doctors Set DoctorFirstName=@p1,DoctorSurName=@p2,DoctorBranch=@p3," +
                "DoctorTC=@p4,DoctorPassword=@p5 Where DoctorTC=@p6", connect.connect());
                cmdUpdateDoctor.Parameters.AddWithValue("@p6", maskedTextBoxTC.Text);
                cmdUpdateDoctor.Parameters.AddWithValue("@p1", txtFirstName.Text);
                cmdUpdateDoctor.Parameters.AddWithValue("@p2", txtSurName.Text);
                cmdUpdateDoctor.Parameters.AddWithValue("@p3", comboBoxBranch.Text);
                cmdUpdateDoctor.Parameters.AddWithValue("@p4", maskedTextBoxTC.Text);
                cmdUpdateDoctor.Parameters.AddWithValue("@p5", txtPassword.Text);
                MessageBox.Show("Successful!", "Update Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdUpdateDoctor.ExecuteNonQuery();
                connect.connect().Close();

                //Updateden sonra datagridViewimizi yenileyelim.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Doctors", dataGridViewDoctor);
               


            }
            else
            {
                MessageBox.Show("Doctor's registration could not be found", "Update ERROR!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                
            }

            connect.connect().Close();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Silinecek veri önce var mı? Onu kontrol edelim.
            SqlCommand cmdCheckDelete = new SqlCommand("Select DoctorTC From Table_Doctors Where DoctorTC=@p1", connect.connect());
            cmdCheckDelete.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            SqlDataReader drCheckDelete = cmdCheckDelete.ExecuteReader();
            if (drCheckDelete.Read())
            {
                SqlCommand cmdDelete = new SqlCommand("Delete From Table_Doctors Where DoctorTC=@p1", connect.connect());
                cmdDelete.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("Deleting the doctor's registration is successful", "Deletion is successful!", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                //Delete işlemi sonrası datagridwievimizi güncelleyelim.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Doctors", dataGridViewDoctor);
            }
            else
            {
                MessageBox.Show("There is already no such record", "The deletion process failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
            connect.connect().Close();
        }

        private void maskedTextBoxTC_TextChanged(object sender, EventArgs e)
        {
            //MaskedTextBoxTC deki girilen TC ye göre verileri kutucuklara gir.
            SqlCommand cmdGetDoctor = new SqlCommand("Select DoctorFirstName,DoctorSurName,DoctorBranch,DoctorPassword" +
                " From Table_Doctors Where DoctorTC=@p1", connect.connect());
            cmdGetDoctor.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            SqlDataReader drGetDoctor = cmdGetDoctor.ExecuteReader();
            while (drGetDoctor.Read())
            {
                txtFirstName.Text = drGetDoctor[0].ToString();
                txtSurName.Text = drGetDoctor[1].ToString();
                comboBoxBranch.Text = drGetDoctor[2].ToString();
                txtPassword.Text = drGetDoctor[3].ToString();
            }
            connect.connect().Close();
        }
    }
}
