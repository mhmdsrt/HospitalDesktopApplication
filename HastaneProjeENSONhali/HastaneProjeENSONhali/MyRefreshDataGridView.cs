using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HastaneProjeENSONhali
{
     class MyRefreshDataGridView
     {
        public string tableName { get; set; }
        public DataGridView dataGridViewName { get; set; }

        Sqlconn connect = new Sqlconn();

        
        //Constructor ile parametre olarak aldığımız dataGridViewizi otomatik olarak yeniliyoruz.
        public MyRefreshDataGridView(string tableName,DataGridView dataGridViewName)
        {
            this.tableName = tableName;
            this.dataGridViewName = dataGridViewName;          
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From " + this.tableName, connect.connect());
            da.Fill(dt);
            dataGridViewName.DataSource = dt;

        }

        //Constructor'ı overloading(Aşırı yükleme) ederek 3 parametreli yazdık.
        public MyRefreshDataGridView(string tableName, DataGridView dataGridViewName,string where)
        {
            this.tableName = tableName;
            this.dataGridViewName = dataGridViewName;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From " + this.tableName+" Where "+where, connect.connect());
            da.Fill(dt);
            dataGridViewName.DataSource = dt;

        }

        

     }
}
