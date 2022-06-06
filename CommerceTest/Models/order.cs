namespace CommerceTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [Key]
        public int id_order { get; set; }

        [Required]
        [StringLength(10)]
        public string code_order { get; set; }

        public int id_client { get; set; }

        public int id_product { get; set; }

        public int amount { get; set; }

        public int price { get; set; }

        public virtual client client { get; set; }

        public virtual product product { get; set; }
    }
}
