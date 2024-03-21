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
    public partial class Form_PatientDetail : Form
    {
        public Form_PatientDetail()
        {
            InitializeComponent();
        }
        Sqlconn connect = new Sqlconn();
        public double tc;
        private void Form_PatientDetail_Load(object sender, EventArgs e)
        {
           //Hasta Bilgilerini Çekme
            
            SqlCommand cmdPatientInformation= new SqlCommand("Select PatientFirstName,PatientSurName from Table_Patients Where PatientTC=@p1",
                connect.connect());
            cmdPatientInformation.Parameters.AddWithValue("@p1",tc);

            SqlDataReader dr= cmdPatientInformation.ExecuteReader();
            if (dr.Read())
            {
                lblTC.Text = tc.ToString();
                lblFirstName.Text = dr[0].ToString();
                lblSurname.Text = dr[1].ToString();
            }
            connect.connect().Close();

            //Branşları ComboBoxa ekleme ----------------------------------------------
            SqlCommand cmdBranch = new SqlCommand("Select BranchName From Table_Branchs",connect.connect());
            SqlDataReader drBranch=cmdBranch.ExecuteReader();
            while(drBranch.Read())
            {
                comboBoxBranch.Items.Add(drBranch[0].ToString());
                
            }
            connect.connect().Close();
            // ----------------------------------------------

            /* 
                Internal Medicine - İç Hastalıkları
                General Surgery - Genel Cerrahi
                Pediatrics - Pediatri (Çocuk Hastalıkları)
                Obstetrics and Gynecology - Kadın Hastalıkları ve Doğum
                Orthopedic Surgery - Ortopedi ve Travmatoloji
                Cardiology - Kardiyoloji
                Dermatology - Dermatoloji
                Neurology - Nöroloji
                Ophthalmology - Göz Hastalıkları (Göz Hastalıkları ve Cerrahisi)
                Psychiatry - Psikiyatr
                Gastroenterology - Gastroenteroloji
                Urology - Üroloji
                Otolaryngology - Kulak Burun Boğaz (KBB)
                Rheumatology - Romatoloji
                Nephrology - Nefroloji (Böbrek Hastalıkları)
             
             */

            //Randevu Geçmişini Datagridwiev'e ekleme           ----------------------------------------------

            DataTable dtAppointHistory = new DataTable();
            SqlDataAdapter daAppointHistory = new SqlDataAdapter("Select * From Table_Appointments Where AppointmentPatientTC='"+
                lblTC.Text+"'"+" "+"and"+" "+"AppointmentStatus='False'", connect.connect());
            daAppointHistory.Fill(dtAppointHistory);
            dataGridViewHistory.DataSource = dtAppointHistory;
            
        }
        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBranch daki seçilen branşa göre ,o branşa ait doktorların getirilmesi.
            comboBoxDoctor.Items.Clear();
            SqlCommand cmdDoctor =new SqlCommand("Select (DoctorFirstName+' '+DoctorSurName) As 'Doctor' From Table_Doctors Where DoctorBranch='"+comboBoxBranch.Text+"'"
                ,connect.connect());

            SqlDataReader drDoctor=cmdDoctor.ExecuteReader();
            while(drDoctor.Read())
            {
                comboBoxDoctor.Items.Add(drDoctor[0].ToString());
            }
            connect.connect().Close();
        }

        
        private void comboBoxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBoxDoctor daki seçilen Doktora göre aktif ranvuları DataGridViewActive de görüntüleme.
            DataTable dtAppointActive = new DataTable();
            SqlDataAdapter daAppointActive = new SqlDataAdapter("Select * From Table_Appointments Where AppointmentDoctor='"+comboBoxDoctor.Text
                +"'"+" and "+"AppointmentBranch='"+comboBoxBranch.Text+"' and "+"AppointmentStatus='True'",connect.connect());
              
            daAppointActive.Fill(dtAppointActive);
            dataGridViewActive.DataSource = dtAppointActive;
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Form_PatientEntry frm = new Form_PatientEntry();
            this.Hide();
            frm.Show();
        }

        private void btnMakeAppointment_Click(object sender, EventArgs e)
        {
            //txtAppointmentID.Text kutumuzu Enabled özelliğini false yapmamıza rağmen yani dışarıdan değer girilmemesine rağmen randevumuzun varlığını teğit edelim.
            //Önce alınmak istenen Randevunun varlığını kontrol ve Durumunu kontrol edelim ki alınan edilen randevu tekrar alınamasın.
            SqlCommand cmdCheckMakeAppoint = new SqlCommand("Select AppointmentID From Table_Appointments Where AppointmentID=@p1 and AppointmentStatus='True'", connect.connect());
            cmdCheckMakeAppoint.Parameters.AddWithValue("@p1", txtAppointmentID.Text);
            SqlDataReader drCheckMakeAppoint = cmdCheckMakeAppoint.ExecuteReader();

            //Eğer o ID ye sahip randevu varsa o zaman randevu alınabilsin.
            if (drCheckMakeAppoint.Read())
            {
                //DatagridViewActive seçtiğimiz randevuyu almak için randevu durumunu artık false yapıyoruz.
                SqlCommand cmdCreateAppoint = new SqlCommand("Update Table_Appointments set AppointmentStatus='False',AppointmentPatientTC=@p2 Where AppointmentID=@p1" +
                    "",
                    connect.connect());
                cmdCreateAppoint.Parameters.AddWithValue("@p1", txtAppointmentID.Text);
                cmdCreateAppoint.Parameters.AddWithValue("@p2", lblTC.Text);
                cmdCreateAppoint.ExecuteNonQuery();

                // Randevuyu oluştururken Şikayeti(Complaint) EKleyeceğiz ama  daha önce o randevuya ait şikayet varmı kontrol edelim.
                SqlCommand cmdCheckComplaint = new SqlCommand("Select ComplaintID From Table_ComplaintS Where ComplaintID=@p1", connect.connect());
                cmdCheckComplaint.Parameters.AddWithValue("@p1", txtAppointmentID.Text);
                SqlDataReader drCheckComplaint = cmdCheckComplaint.ExecuteReader();
                if (drCheckComplaint.Read())
                {
                    MessageBox.Show("There is already such a complaint", "Adding a complaint and creating an appointment failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Randevuyu oluştururken Şikayeti(Complaint) EKleme.
                    SqlCommand cmdInsertComplaint = new SqlCommand("Insert Into Table_Complaints (ComplaintID,Complaint) Values(@p1,@p2)", connect.connect());
                    cmdInsertComplaint.Parameters.AddWithValue("@p1", txtAppointmentID.Text);
                    cmdInsertComplaint.Parameters.AddWithValue("@p2", richTextBoxComplaint.Text);
                    cmdInsertComplaint.ExecuteNonQuery();
                }
                                              
                MessageBox.Show("Appointment was created", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAppointmentID.Text = "";               
                //Randevumuzu aldıktan sonra datagridviewActive ve datagridviewHistory verilerimizi yeniliyelim.
                string doctor = comboBoxDoctor.Text;
                string branch = comboBoxBranch.Text;
                //Giriş yapılan hastaya ait geçmiş randevuları görüntüleme
                MyRefreshDataGridView refreshHistory = new MyRefreshDataGridView("Table_Appointments", dataGridViewHistory, "AppointmentStatus='False' and AppointmentPatientTC=" + lblTC.Text);
                //O doktora ve branşa ait müsait randevuları görüntüleme
                MyRefreshDataGridView refreshActive = new MyRefreshDataGridView("Table_Appointments", dataGridViewActive, "AppointmentStatus='True' and AppointmentBranch='" + branch +
                    "' and AppointmentDoctor='" + doctor + "'");

               
                
            }
            else
            {
                MessageBox.Show("An Appointment with this ID could not be found", "Unseccessful!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
            

        }

        private void dataGridViewActive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DatagridViewActive herhangi bir hücresine tıklandığında o satırdaki randevunun ID numarasını alma.
            int indexActive = dataGridViewActive.SelectedCells[0].RowIndex;
            txtAppointmentID.Text = dataGridViewActive.Rows[indexActive].Cells[0].Value.ToString();
            

        }

        private void dataGridViewHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DatagridViewHistory herhangi bir hücresine tıklandığında o satırdaki randevunun ID numarasını,branşını ve doktor isimlerini alma.
            int indexHistory = dataGridViewHistory.SelectedCells[0].RowIndex;
            txtAppointmentID.Text = dataGridViewHistory.Rows[indexHistory].Cells[0].Value.ToString();
            comboBoxBranch.Text = dataGridViewHistory.Rows[indexHistory].Cells[3].Value.ToString();
            comboBoxDoctor.Text = dataGridViewHistory.Rows[indexHistory].Cells[4].Value.ToString();



        }

        private void btnCancelAppoint_Click(object sender, EventArgs e)
        {
            //Önce iptal etmek istediğimiz randevunun varlığını ve Durumunu kontrol edelim ki iptal edilen randevu tekrar iptal edilemesin.
            SqlCommand cmdCheckCancelAppoint = new SqlCommand("Select AppointmentID From Table_Appointments Where AppointmentID=@p1 and AppointmentStatus='False'", connect.connect());
            cmdCheckCancelAppoint.Parameters.AddWithValue("@p1", txtAppointmentID.Text);
            SqlDataReader drCheckCancelAppoint = cmdCheckCancelAppoint.ExecuteReader();
            if (drCheckCancelAppoint.Read())
            {
                //Randevumuzu iptal etmek için AppointmentStatus(Randevu Durumu) nu artık True yapıyoruz.
                SqlCommand cmdCancelAppoint = new SqlCommand("Update Table_Appointments Set AppointmentStatus='True',AppointmentPatientTC=NULL Where AppointmentID=@p1", connect.connect());
                cmdCancelAppoint.Parameters.AddWithValue("@p1", txtAppointmentID.Text);
                cmdCancelAppoint.ExecuteNonQuery();

                //Randevu iptal edildikten sonra complaints tablosunda da aynı randevunun compliant(Sikayet) kısmı silinmesi.
                SqlCommand cmdDeleteComplaint = new SqlCommand("Delete From Table_Complaints Where ComplaintID=@p1", connect.connect());
                cmdDeleteComplaint.Parameters.AddWithValue("@p1", txtAppointmentID.Text);
                cmdDeleteComplaint.ExecuteNonQuery();


                MessageBox.Show("The appointment was canceled", "Cancellation is successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAppointmentID.Text = "";
                //Randevumuzu iptal ettikten sonra datagridviewActive ve datagridviewHistory verilerimizi yeniliyelim.
                string doctor = comboBoxDoctor.Text;
                string branch = comboBoxBranch.Text;
                //Giriş yapılan hastaya ait geçmiş randevuları görüntüleme
                MyRefreshDataGridView refreshHistory = new MyRefreshDataGridView("Table_Appointments", dataGridViewHistory, "AppointmentStatus='False' and AppointmentPatientTC=" + lblTC.Text);
                //O doktora ve branşa ait müsait randevuları görüntüleme
                MyRefreshDataGridView refreshActive = new MyRefreshDataGridView("Table_Appointments", dataGridViewActive, "AppointmentStatus='True' and AppointmentBranch='" + branch +
                    "' and AppointmentDoctor='" + doctor + "'");
            }
            else
            {
                MessageBox.Show("An Appointment with this ID could not be found", "Unseccessful!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
        }
    }
}
