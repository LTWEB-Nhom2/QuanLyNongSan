namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("product")]
    public partial class product
    { 
        public product()
        {

        }
        [Key]
        public int product_id { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập vào mã danh mục")]
        public int? product_category_id { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập vào tên sản phẩm")]
        [StringLength(255)]
        public string product_name { get; set; }

        [StringLength(1000)]
        public string product_description { get; set; }

        [StringLength(1000)]
        public string product_thumbnail_image { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập vào giá của sản phẩm")]
        public decimal? product_price { get; set; }


    }
    class ListProduct
    {
        DBConnection db;
        public ListProduct()
        {
            db = new DBConnection();

        }
        public List<product> getData()
        {
            string sql;

            sql = "Select * from product";


            List<product> list = new List<product>();
            SqlConnection con = db.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product item = new product();
                item.product_id = int.Parse(dr["product_id"].ToString());
                item.product_price = decimal.Parse(dr["product_price"].ToString());
                item.product_description = dr["product_description"].ToString();
                item.product_thumbnail_image = dr["product_thumbnail_image"].ToString();
                item.product_name = dr["product_name"].ToString();
                item.product_category_id = int.Parse(dr["product_category_id"].ToString());
                list.Add(item);
            }
            con.Close();
            return list;

        }

    }
}
