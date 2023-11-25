using NongSanDungHa.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class admin_account
    {
        [Key]
        public int admin_account_id { get; set; }

        [StringLength(255)]
        public string admin_username { get; set; }

        [StringLength(255)]

        public string admin_password { get; set; }
    }
   
    class ListAdminAccount
    {
        DBConnection db;
        public ListAdminAccount()
        {
            db = new DBConnection();

        }
        public List<admin_account> getData()
        {
            string sql;

            sql = "Select * from admin_account";


            List<admin_account> list = new List<admin_account>();
            SqlConnection con = db.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                admin_account item = new admin_account();
                item.admin_account_id = int.Parse(dr["admin_account_id"].ToString());
                item.admin_username = dr["admin_username"].ToString();
                item.admin_password = dr["admin_password"].ToString();
                list.Add(item);
            }
            con.Close();
            return list;

        }

    }
}
