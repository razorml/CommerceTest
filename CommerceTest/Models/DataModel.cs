using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CommerceTest.Models
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.id_category)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.name_category)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .Property(e => e.type_document)
                .IsFixedLength();

            modelBuilder.Entity<client>()
                .Property(e => e.names)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.last_names)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .Property(e => e.code_order)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.name_product)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.desc_product)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.serial_product)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.id_category)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);
        }
    }
}
