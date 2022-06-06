namespace CommerceTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("client")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int id_client { get; set; }

        [Required]
        [StringLength(10)]
        public string type_document { get; set; }

        public int num_doc_client { get; set; }

        [Required]
        [StringLength(50)]
        public string names { get; set; }

        [Required]
        [StringLength(50)]
        public string last_names { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public int telephone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
