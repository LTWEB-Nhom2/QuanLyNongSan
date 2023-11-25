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
    using System.Data.SqlClient;

    public partial class product_image
    {
        public product_image() { }
        [Key]
        public int product_image_id { get; set; }

        public int? product_id { get; set; }

        [StringLength(1000)]
        public string product_image_file_name { get; set; }
        
    }
class ListProductImage
{
    DBConnection db;
    public ListProductImage()
    {
        db = new DBConnection();

    }
    public List<product_image> getData()
    {
        string sql;

        sql = "Select * from product_image";


        List<product_image> list = new List<product_image>();
        SqlConnection con = db.GetConnection();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            product_image item = new product_image();
            item.product_image_id = int.Parse(dr["product_image_id"].ToString());
            item.product_id = int.Parse(dr["product_id"].ToString());
            item.product_image_file_name = dr["product_image_file_name"].ToString();

            list.Add(item);
        }
        con.Close();
        return list;

    }

}
}
