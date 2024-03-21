using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProjeENSONhali
{
    public partial class Form_Base : Form
    {
        public Form_Base()
        {
            InitializeComponent();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Form_PatientEntry form = new Form_PatientEntry();
            form.Show();
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            Form_DoctorEntry frm = new Form_DoctorEntry();
            this.Hide();
            frm.Show();
        }

        private void btnSecretary_Click(object sender, EventArgs e)
        {
            Form_SecretaryEntry frm = new Form_SecretaryEntry();
            this.Hide();
            frm.Show();
        }
    }
}
