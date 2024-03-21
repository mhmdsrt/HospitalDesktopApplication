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
    public partial class Form_DoctorDetail : Form
    {
        public Form_DoctorDetail()
        {
            InitializeComponent();
        }
        public double tc;
        Sqlconn connect = new Sqlconn();
        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Form_DoctorEntry frm = new Form_DoctorEntry();
            this.Hide();
            frm.Show();
        }

        private void btnViewAnnoun_Click(object sender, EventArgs e)
        {
            Form_Announcements frm = new Form_Announcements();
            frm.Show();
        }

        private void Form_DoctorDetail_Load(object sender, EventArgs e)
        {
            //Doktor bilgilerini çekme.
            SqlCommand cmdGetDoctor= new SqlCommand("Select DoctorFirstName,DoctorSurName From Table_Doctors" +
                " Where DoctorTC=@p1", connect.connect());
            cmdGetDoctor.Parameters.AddWithValue("@p1", tc);
            SqlDataReader drGetDoctor = cmdGetDoctor.ExecuteReader();
            while (drGetDoctor.Read())
            {
                lblFirstName.Text = drGetDoctor[0].ToString();
                lblSurname.Text = drGetDoctor[1].ToString();
                lblTC.Text = tc.ToString();
            }

            // Mevcut doktora ait Randevuları datagridviewe çekme.
            MyRefreshDataGridView getAppoint = new MyRefreshDataGridView("Table_Appointments", dataGridViewAppoint,
                "AppointmentDoctor='" + lblFirstName.Text+" " + lblSurname.Text+"'");

        }

        private void dataGridViewAppoint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DatagridViewdeki seçilen hücrenin satırına ait randevunun şikayetini ,richtexboxa(Complaint) aktarma.Bunun için seçilen randevunun ID numarasını alıcaz.
            int index = dataGridViewAppoint.SelectedCells[0].RowIndex;
            var appointID = dataGridViewAppoint.Rows[index].Cells[0].Value;

            SqlCommand cmdGetComplaint = new SqlCommand("Select Complaint From Table_Complaints Where ComplaintID=@p1", connect.connect());
            cmdGetComplaint.Parameters.AddWithValue("@p1", appointID);
            SqlDataReader drGetComplaint = cmdGetComplaint.ExecuteReader();
            richTextBoxComplaint.Text = "";
            while (drGetComplaint.Read())
            {

                richTextBoxComplaint.Text = drGetComplaint[0].ToString();
            }



        }
    }
}
