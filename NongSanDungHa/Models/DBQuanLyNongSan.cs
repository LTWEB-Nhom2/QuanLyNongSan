using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;

namespace NongSanDungHa.Models
{
    public partial class DBConnection
    {
        string strCon;
       
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["QuanLyNongSanConnectionString"].ConnectionString;
            Con.ConnectionString = strCon; // ket noi cach 2
            
            SqlCommand sqlCommand = Con.CreateCommand();
            Cmd = sqlCommand;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }
        SqlConnection con = new SqlConnection();
        public SqlConnection Con
        {
            get { return con; }
            set { con = value; }
        }
        SqlCommand cmd;

        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
            set { reader = value; }
        }
    }
}
