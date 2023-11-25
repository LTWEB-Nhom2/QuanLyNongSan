namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_order()
        {
            user_order_product = new HashSet<user_order_product>();
        }

            [Key]
            public int user_order_id { get; set; }

            public int? user_account_id { get; set; }

            [Column(TypeName = "date")]
            public DateTime? order_time { get; set; }

            [StringLength(255)]
            public string user_order_buyer_name { get; set; }

            [StringLength(255)]
            public string user_order_address { get; set; }

            [StringLength(255)]
            public string user_order_email { get; set; }

            [StringLength(20)]
            public string user_order_phonenumber { get; set; }

            [StringLength(20)]
            public string is_processed { get; set; }

            [StringLength(20)]
            public string is_delivered { get; set; }

            public decimal? order_total_value { get; set; }

        public virtual user_account user_account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_order_product> user_order_product { get; set; }
    }
}
