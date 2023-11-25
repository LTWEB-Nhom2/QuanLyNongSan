namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class product_category
    {
        public product_category() { }
        [Key]
        public int product_category_id { get; set; }

        [StringLength(255)]
        public string product_category_name { get; set; }

        [StringLength(255)]
        public string product_category_description { get; set; }
    }
    class ListProductCategory
    {
        DBConnection db;
        public ListProductCategory()
        {
            db = new DBConnection();

        }
        public List<product_category> getData()
        {
            string sql;

            sql = "Select * from product_category";


            List<product_category> list = new List<product_category>();
            SqlConnection con = db.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_category item = new product_category();
                item.product_category_id = int.Parse(dr["product_category_id"].ToString());
                item.product_category_name = dr["product_category_name"].ToString();
                item.product_category_description = dr["product_category_description"].ToString();
                list.Add(item);
            }
            con.Close();
            return list;

        }

    }
}

