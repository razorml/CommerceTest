namespace CommerceTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int id_product { get; set; }

        [Required]
        [StringLength(50)]
        public string name_product { get; set; }

        [Required]
        [StringLength(50)]
        public string desc_product { get; set; }

        [Required]
        [StringLength(50)]
        public string serial_product { get; set; }

        public int price_product { get; set; }

        [Required]
        [StringLength(3)]
        public string id_category { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        #region metodos

        public List<product> GetProducts() 
        {
            var product = new List<product>();
            string script = "SELECT * FROM product";
            try
            {
                using (var content = new DataModel())
                {
                    product = content.Database.SqlQuery<product>(script).ToList();
                }
            }
            catch (Exception)
            {

            }
            return product;
        }

        public List<category> GetCategory()
        {
            var category = new List<category>();
            string script = "SELECT * FROM category";
            try
            {
                using (var content = new DataModel())
                {
                    category = content.Database.SqlQuery<category>(script).ToList();
                }
            }
            catch (Exception)
            {

            }
            return category;
        }

        public bool InsertProduct(string name, string description, string serial, string price, string category) 
        {
            bool state = false;
            string script = "'" + name + "',";
            script += "'" + description + "',";
            script += "'" + serial + "',";
            script += "'" + price + "',";
            script += "'" + category + "'";
            try
            {
                using (var content = new DataModel())
                {
                    int result = content.Database.ExecuteSqlCommand("INSERT INTO PRODUCT VALUES (" + script + ")");
                    if (result == 1) 
                    {
                        state = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                state = false;
            }
            return state;
        }

        public product GetProductId(int id) 
        {
            var product = new product();
            try
            {
                using (var content = new DataModel())
                {
                    product = content.products.Where(x => x.id_product == id).Single();
                }
            }
            catch (Exception)
            {
                                
            }
            return product;
        } 

        public bool UpdateProduct(string id, string name, string description, string serial, string price, string category) 
        {
            bool state = false;
            string script = "name_product = '" + name + "',";
            script += "desc_product = '" + description + "',";
            script += "serial_product = '" + serial + "',";
            script += "price_product = '" + price + "',";
            script += "id_category = '" + category + "'";
            try
            {
                using (var content = new DataModel())
                {
                    int result = content.Database.ExecuteSqlCommand("UPDATE PRODUCT SET " + script + " WHERE id_product = "+id);
                    if (result == 1)
                    {
                        state = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                state = false;
            }
            return state;
        }

        public bool DeleteProduct(int id) 
        {
            bool state = false;          
            try
            {
                using (var content = new DataModel())
                {
                    int result = content.Database.ExecuteSqlCommand("DELETE FROM PRODUCT WHERE id_product = " + id);
                    if (result == 1)
                    {
                        state = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                state = false;
            }
            return state;
        }
        #endregion
    }
}
