using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneProjeENSONhali
{
    class Sqlconn
    {
        //Constructor ile Sql bağlantımızı açıyoruz ve geriye bağlantı adresimizi döndürüyoruz.
        public SqlConnection connect()
        {
            SqlConnection connectionAdress = new SqlConnection("Data Source=DESKTOP-50T6SSM\\SQLEXPRESS;Initial Catalog=hastaneprojeson;Integrated Security=True");

            connectionAdress.Open();
            return connectionAdress;
        }

    }
}
