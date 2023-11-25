namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product_review
    {
        [Key]
        public int product_review_id { get; set; }

        public int? user_account_id { get; set; }

        public int? product_id { get; set; }

        [StringLength(255)]
        public string product_review_content { get; set; }

        [StringLength(255)]
        public string review_owner { get; set; }

        public virtual product product { get; set; }

        public virtual user_account user_account { get; set; }
    }
}
