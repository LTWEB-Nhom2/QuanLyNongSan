namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class product_discount_event
    {
        public product_discount_event() { }
        [Key]
        public int discount_event_id { get; set; }

        [StringLength(1000)]
        public string discount_event_image { get; set; }

        [StringLength(255)]
        public string discount_event_name { get; set; }

        [StringLength(255)]
        public string discount_event_description { get; set; }

        public DateTime? discount_event_DateCreated { get; set; }

        public int? product_category_id { get; set; }

    }
    class ListDiscountEvent
    {
        DBConnection db;
        public ListDiscountEvent()
        {
            db = new DBConnection();

        }
        public List<product_discount_event> getData()
        {
            string sql;

            sql = "Select * from product_discount_event";


            List<product_discount_event> list = new List<product_discount_event>();
            SqlConnection con = db.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_discount_event item = new product_discount_event();
                item.discount_event_id = int.Parse(dr["discount_event_id"].ToString());
                item.discount_event_image = dr["discount_event_image"].ToString();
                item.discount_event_description = dr["discount_event_description"].ToString();
                item.discount_event_DateCreated = DateTime.Parse(dr["discount_event_DateCreated"].ToString());
                item.discount_event_name = dr["discount_event_name"].ToString();
                list.Add(item);
            }
            con.Close();
            return list;

        }

    }
}
