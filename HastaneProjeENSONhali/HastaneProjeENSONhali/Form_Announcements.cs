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
    public partial class Form_Announcements : Form
    {
        public Form_Announcements()
        {
            InitializeComponent();
        }
        Sqlconn connect = new Sqlconn();
        private void Form_Announcements_Load(object sender, EventArgs e)
        {
            DataTable dtAnnoun = new DataTable();
            SqlDataAdapter daAnnoun = new SqlDataAdapter("Select Announcement From Table_Announcements", connect.connect());
            daAnnoun.Fill(dtAnnoun);
            dataGridViewAnnoun.DataSource = dtAnnoun;
        }
    }
}
