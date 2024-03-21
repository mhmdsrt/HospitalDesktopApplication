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
    public partial class Form_SecretaryDetail : Form
    {
        public Form_SecretaryDetail()
        {
            InitializeComponent();
        }

        Sqlconn connect = new Sqlconn();
        public double TC;
        
        private void Form_SecretaryDetail_Load(object sender, EventArgs e)
        {
            
            //Sekreter Bilgilerini Getir.
            SqlCommand cmdGetSecretary = new SqlCommand("Select SecretaryFirstName,SecretarySurName From " +
                "Table_Secretarys Where SecretaryTC=@p1", connect.connect());
            cmdGetSecretary.Parameters.AddWithValue("@p1",TC);
            SqlDataReader drGetSecretary = cmdGetSecretary.ExecuteReader();
            if (drGetSecretary.Read())
            {
                lblTC.Text = TC.ToString();
                lblFirstName.Text = drGetSecretary[0].ToString();
                lblSurname.Text = drGetSecretary[1].ToString();
            }
            connect.connect().Close();


            //Branşları DatagridViewe ekleme.
            DataTable dtBranchs = new DataTable();
            SqlDataAdapter daBranchs = new SqlDataAdapter("Select BranchName As 'Branch Name' From Table_Branchs",connect.connect());
            daBranchs.Fill(dtBranchs);
            dataGridViewBranchs.DataSource = dtBranchs;


            //Doktorları DatagridViewe ekleme.
            DataTable dtDoctors = new DataTable();
            SqlDataAdapter daDoctors = new SqlDataAdapter("Select (DoctorFirstName+' '+DoctorSurName) As 'Doctor'  From Table_Doctors", 
                connect.connect());
            daDoctors.Fill(dtDoctors);
            dataGridViewDoctors.DataSource = dtDoctors;

            //Randevuları DatagridViewe Ekleme.

            MyRefreshDataGridView refreshAppoint = new MyRefreshDataGridView("Table_Appointments",dataGridViewAppointments);
           

            //Branşları ComboBoxa Getirme
            SqlCommand cmdGetBranch = new SqlCommand("Select BranchName From Table_Branchs", connect.connect());
            SqlDataReader drGetBranch = cmdGetBranch.ExecuteReader();
            while (drGetBranch.Read())
            {
                comboBoxBranch.Items.Add(drGetBranch[0].ToString());
            }
            connect.connect().Close();

        }
       private void btnSave_Click(object sender, EventArgs e)
        {
            //Randevu Daha önce oluşturuldu mu?  Kontrol ediyoruz aşağıda.
            SqlCommand cmdSave = new SqlCommand("Insert into Table_Appointments (AppointmentDate,AppointmentTime,AppointmentBranch," +
                "AppointmentDoctor,AppointmentStatus,AppointmentPatientTC) Values (@p1,@p2,@p3,@p4,@p5,@p6)",connect.connect());
            cmdSave.Parameters.AddWithValue("@p1", maskedTextBoxDate.Text);
            cmdSave.Parameters.AddWithValue("@p2", maskedTextBoxTime.Text);
            cmdSave.Parameters.AddWithValue("@p3", comboBoxBranch.Text);
            cmdSave.Parameters.AddWithValue("@p4", comboBoxDoctor.Text);

            if (radiobtnAvailable.Checked == true)
            {
                cmdSave.Parameters.AddWithValue("@p5", "True");

            }
            else if (radiobtnBusy.Checked == true)
            {
                cmdSave.Parameters.AddWithValue("@p5", "False");

            }

            cmdSave.Parameters.AddWithValue("@p6", maskedTextBoxTC.Text);
            connect.connect().Close();

            //Randevu Daha önce oluşturuldu mu?  Kontrol et.
            SqlCommand cmdCheckAppoint = new SqlCommand("Select AppointmentDate,AppointmentTime,AppointmentDoctor From Table_Appointments Where AppointmentDate=@p1 and " +
                "AppointmentTime=@p2 and AppointmentDoctor=@p3", connect.connect());
            cmdCheckAppoint.Parameters.AddWithValue("@p1", maskedTextBoxDate.Text);
            cmdCheckAppoint.Parameters.AddWithValue("@p2", maskedTextBoxTime.Text);
            cmdCheckAppoint.Parameters.AddWithValue("@p3", comboBoxDoctor.Text);
            SqlDataReader drCheckAppoint = cmdCheckAppoint.ExecuteReader();
            if (drCheckAppoint.Read())
            {
                MessageBox.Show("The Appointment has already Been Made", "Appointment creation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Randevu daha önce Oluşturulmadıysa artık o zaman kaydet.
            else
            {
                cmdSave.ExecuteNonQuery();
                MessageBox.Show("Appointment was created", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Insert sonrası datagridviewi yeniliyelim.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Appointments", dataGridViewAppointments);

                
            }

            connect.connect().Close();

        }

        private void txtAppointID_TextChanged(object sender, EventArgs e)
        {
            //txtAppointID kutusundaki numarayı temizlediğimizde tüm Kutucukları temizle.
            if (txtAppointID.Text == "")
            {
                maskedTextBoxDate.Text = "";
                maskedTextBoxTime.Text = "";
                comboBoxBranch.Text ="";
                comboBoxDoctor.Text = "";
                radiobtnAvailable.Checked = false;
                radiobtnBusy.Checked = false;
                maskedTextBoxTC.Text = "";

            }

            //AppointmentID text Boxundaki girilen ID numarasına göre Randevu bilgilerini kutulara yazma
            SqlCommand cmdGetAppointment = new SqlCommand("Select AppointmentDate,AppointmentTime,AppointmentBranch," +
                "AppointmentDoctor," +"AppointmentStatus,AppointmentPatientTC From Table_Appointments" +
                " Where AppointmentID=@p1",connect.connect());
            cmdGetAppointment.Parameters.AddWithValue("@p1", txtAppointID.Text);
            SqlDataReader drGetAppointment = cmdGetAppointment.ExecuteReader();
            while (drGetAppointment.Read())
            {
                maskedTextBoxDate.Text = drGetAppointment[0].ToString();
                maskedTextBoxTime.Text = drGetAppointment[1].ToString();
                comboBoxBranch.Text = drGetAppointment[2].ToString();
                comboBoxDoctor.Text = drGetAppointment[3].ToString();

                if (drGetAppointment[4].ToString() == "True")
                {
                    radiobtnAvailable.Checked = true;
                }
                else if (drGetAppointment[4].ToString() == "False")
                {
                    radiobtnBusy.Checked = true;
                }

                maskedTextBoxTC.Text = drGetAppointment[5].ToString();
                
            }
            connect.connect().Close();
        }
       
        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBoxBranch daki seçilen branşa göre comboBoxDoctora ,o branşa ait doktorları getirme.
            comboBoxDoctor.Items.Clear();
            SqlCommand cmdGetDoctor = new SqlCommand("Select (DoctorFirstName+' '+DoctorSurName) as 'Doctor' From Table_Doctors Where " +
                "DoctorBranch='"+comboBoxBranch.Text+"'",connect.connect());
            SqlDataReader drGetDoctor = cmdGetDoctor.ExecuteReader();
            while (drGetDoctor.Read())
            {
                comboBoxDoctor.Items.Add(drGetDoctor[0].ToString());
            }
            connect.connect().Close();
        }

        private void btnAnnoun_Click(object sender, EventArgs e)
        {
            SqlCommand cmdCreateAnnoun = new SqlCommand("Insert Into Table_Announcements(Announcement) VALUES (@p1)", connect.connect());
            cmdCreateAnnoun.Parameters.AddWithValue("@p1", richTextBoxAnno.Text);
            cmdCreateAnnoun.ExecuteNonQuery();
            MessageBox.Show("Successful", "creating an announcement was successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connect.connect().Close();
        }

        private void btnDoctorEdit_Click(object sender, EventArgs e)
        {
            /*DoctorEdit formundan tekrar geri gelip SecretaryDetail formuna geri döneceğimiz zaman ,tekrardan sekreter-
            bilgilerini geri getirebilmek için aşağıdaki kodu yazıyoruz.*/
            Form_DoctorEdit frm = new Form_DoctorEdit();
            this.Hide();
            frm.secretaryTC = this.TC;
            frm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Önce güncellenecek olan kayıt var mı kontrol edelim ki varolan bir randevuyu güncelleyelim!
            SqlCommand cmdCheckUpdate = new SqlCommand("Select AppointmentID From Table_Appointments Where AppointmentID=@p1", connect.connect());
            cmdCheckUpdate.Parameters.AddWithValue("@p1", txtAppointID.Text);
            SqlDataReader drCheckUpdate = cmdCheckUpdate.ExecuteReader();
            if (drCheckUpdate.Read())
            {
                connect.connect().Close();
                SqlCommand cmdUpdate = new SqlCommand("Update Table_Appointments Set AppointmentDate=@p1,AppointmentTime=@p2,AppointmentBranch=@p3," +
                "AppointmentDoctor=@p4,AppointmentStatus=@p5,AppointmentPatientTC=@P6 Where AppointmentID=@p7", connect.connect());
                cmdUpdate.Parameters.AddWithValue("@p1", maskedTextBoxDate.Text);
                cmdUpdate.Parameters.AddWithValue("@p2", maskedTextBoxTime.Text);
                cmdUpdate.Parameters.AddWithValue("@p3", comboBoxBranch.Text);
                cmdUpdate.Parameters.AddWithValue("@p4", comboBoxDoctor.Text);

                if (radiobtnAvailable.Checked == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@p5", "True");

                }

                else if (radiobtnBusy.Checked == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@p5", "False");

                }
                cmdUpdate.Parameters.AddWithValue("@p6", maskedTextBoxTC.Text);
                cmdUpdate.Parameters.AddWithValue("@p7", txtAppointID.Text);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Successful!", "Update Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Guncelleme sonrası datagridviewi yeniyelim.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Appointments", dataGridViewAppointments);

            }
            else
            {
                MessageBox.Show("Doctor's registration could not be found", "Update ERROR!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            connect.connect().Close();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Kutucukları temizleme.
            txtAppointID.Text = "";
            maskedTextBoxDate.Text = "";
            maskedTextBoxTime.Text = "";
            comboBoxBranch.Text = "";
            comboBoxDoctor.Text = "";
            radiobtnAvailable.Checked = false;
            radiobtnBusy.Checked = false;
            maskedTextBoxTC.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Önce silinecek verimizin varlığını kontrol edelim.
            SqlCommand cmdCheckDelete = new SqlCommand("Select AppointmentID From Table_Appointments Where AppointmentID=@p1", connect.connect());
            cmdCheckDelete.Parameters.AddWithValue("@p1", txtAppointID.Text);
            SqlDataReader drCheckDelete = cmdCheckDelete.ExecuteReader();
            if (drCheckDelete.Read())
            {
                connect.connect().Close();
                SqlCommand cmdDelete = new SqlCommand("Delete From Table_Appointments Where AppointmentID=@p1", connect.connect());
                cmdDelete.Parameters.AddWithValue("@p1", txtAppointID.Text);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("The appointment was deleted", "The deletion process is successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Silme sonrası datagridviewi yeniyelim.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Appointments", dataGridViewAppointments);

            }

            else
            {
                MessageBox.Show("There is already no registration", "Deletion of the registration failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connect.connect().Close();

        }

        private void dataGridViewAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Appointments Datagridviewe herhangibir hücreye tıklandığı zaman o hücreye ait satır bilgilerini textBoxlara getirme.
            int index = dataGridViewAppointments.SelectedCells[0].RowIndex;
            txtAppointID.Text = dataGridViewAppointments.Rows[index].Cells[0].Value.ToString();
            maskedTextBoxDate.Text = dataGridViewAppointments.Rows[index].Cells[1].Value.ToString();
            maskedTextBoxTime.Text = dataGridViewAppointments.Rows[index].Cells[2].Value.ToString();
            comboBoxBranch.Text = dataGridViewAppointments.Rows[index].Cells[3].Value.ToString();
            comboBoxDoctor.Text = dataGridViewAppointments.Rows[index].Cells[4].Value.ToString();

            if (dataGridViewAppointments.Rows[index].Cells[5].Value.ToString() == "True")
            {
                radiobtnAvailable.Checked = true;
                radiobtnBusy.Checked = false;
            }
            else if (dataGridViewAppointments.Rows[index].Cells[5].Value.ToString() == "False")
            {
                radiobtnBusy.Checked = true;
                radiobtnAvailable.Checked = false;
            }
            maskedTextBoxTC.Text = dataGridViewAppointments.Rows[index].Cells[6].Value.ToString();
        }

        private void btnBrachEdit_Click(object sender, EventArgs e)
        {
            Form_BranchEdit frm = new Form_BranchEdit();
            this.Hide();
            frm.Show();
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Form_SecretaryEntry frm = new Form_SecretaryEntry();
            this.Hide();
            frm.Show();
        }

        

        private void btnViewAnnoun_Click(object sender, EventArgs e)
        {
            Form_Announcements frm = new Form_Announcements();
            frm.Show();
        }
    }
}
