namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_order_product
    {
        [Key]
        [Column(Order = 0)]
        public int user_order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id { get; set; }

        [StringLength(255)]
        public string product_name { get; set; }

        public int? order_product_amount { get; set; }

        public virtual product product { get; set; }

        public virtual user_order user_order { get; set; }
    }
}
