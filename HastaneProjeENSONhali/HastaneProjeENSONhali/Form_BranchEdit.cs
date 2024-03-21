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
    public partial class Form_BranchEdit : Form
    {
        public Form_BranchEdit()
        {
            InitializeComponent();
        }
        Sqlconn connect = new Sqlconn();
        private void btnComeBack_Click(object sender, EventArgs e)
        {
            Form_SecretaryDetail frm = new Form_SecretaryDetail();
            this.Hide();
            frm.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Branş oluşturmadan önce daha önce oluşturulup-oluşturulmadığını kontrol ediyoruz.
            SqlCommand cmdCheckCreate = new SqlCommand("Select BranchName From Table_Branchs Where BranchName=@p1", connect.connect());
            cmdCheckCreate.Parameters.AddWithValue("@p1", txtBranchName.Text);
            SqlDataReader drCheckCreate = cmdCheckCreate.ExecuteReader();
            if (drCheckCreate.Read())
            {
                MessageBox.Show("The branch is already registered", "Inserted is unsuccessful!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                connect.connect().Close();
                SqlCommand cmdCreate = new SqlCommand("Insert Into Table_Branchs(BranchName) Values(@p1)", connect.connect());
                cmdCreate.Parameters.AddWithValue("@p1", txtBranchName.Text);
                cmdCreate.ExecuteNonQuery();
                MessageBox.Show("Adding a branch is successful", "Succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ekleme sonrasında datagridviewi yeniliyoruz.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Branchs", dataGridViewBranchs);
            }
            
            
        }

        private void Form_BranchEdit_Load(object sender, EventArgs e)
        {
            MyRefreshDataGridView getBranchs = new MyRefreshDataGridView("Table_Branchs", dataGridViewBranchs);
        }

        private void dataGridViewBranchs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagridviewdeki tıklanan herhangi bir hücrenin satırındaki bilgileri textboxa aktarma.
            int index = dataGridViewBranchs.SelectedCells[0].RowIndex;
            txtBranchID.Text = dataGridViewBranchs.Rows[index].Cells[0].Value.ToString();
            txtBranchName.Text = dataGridViewBranchs.Rows[index].Cells[1].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Güncellenecek kayıt var mı?Önce onu kontrol edelim.
            SqlCommand checkUpdate = new SqlCommand("Select BranchID From Table_Branchs Where BranchID=@p1", connect.connect());
            checkUpdate.Parameters.AddWithValue("@p1", txtBranchID.Text);
            SqlDataReader drCheckUpdate = checkUpdate.ExecuteReader();
            if (drCheckUpdate.Read())
            {
                connect.connect().Close();
                SqlCommand cmdUpdate = new SqlCommand("Update Table_Branchs Set BranchName=@p1 Where BranchID=@p2", connect.connect());
                cmdUpdate.Parameters.AddWithValue("@p1", txtBranchName.Text);
                cmdUpdate.Parameters.AddWithValue("@p2", txtBranchID.Text);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Update is successful!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Guncelleme sonrası datagridviewi yenileyelim.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Branchs", dataGridViewBranchs);
            }
            else
            {
                MessageBox.Show("The updated record could not be found", "Update is unsuccessful!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connect.connect().Close();



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Önce silinecek bir kayıt var mı? Onu kontrol etmemiz lazım.
            SqlCommand cmdCheckDelete = new SqlCommand("Select * From Table_Branchs Where BranchName=@p1 and BranchID=@p2", connect.connect());
            cmdCheckDelete.Parameters.AddWithValue("@p1", txtBranchName.Text);
            cmdCheckDelete.Parameters.AddWithValue("@p2", txtBranchID.Text);
            SqlDataReader drCheckDelete = cmdCheckDelete.ExecuteReader();
            if (drCheckDelete.Read())
            {
                connect.connect().Close();
                SqlCommand cmdDelete = new SqlCommand("Delete From Table_Branchs Where BranchName=@p1 and BranchID=@p2", connect.connect());
                cmdDelete.Parameters.AddWithValue("@p1", txtBranchName.Text);
                cmdDelete.Parameters.AddWithValue("@p2", txtBranchID.Text);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("Delete is successful!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Silinme işlemi sonrası datagridviewimizi yenileyelim.
                MyRefreshDataGridView refresh = new MyRefreshDataGridView("Table_Branchs", dataGridViewBranchs);
            }
            else
            {
                MessageBox.Show("There is already no such record", "Deletion failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connect.connect().Close();
        }
    }
}
