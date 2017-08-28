using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vaibhavgrid.Models
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> TblCustomers { get; set; }
        public DbSet<Order> TblOrders { get; set; }
        public DbSet<Product> TblProducts { get; set; }

        public SalesContext() : base("MyConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //S3: The Max lenght for the CustomerName (80),Address(100), MobileNo(14),PhoneNo(20),City(40),District(40),State(20)
            modelBuilder.Entity<Customer>().Property(c =>
             c.CustomerName).HasMaxLength(80);
            modelBuilder.Entity<Customer>().Property(c =>
             c.Address).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c =>
             c.MobileNo).HasMaxLength(14);
            modelBuilder.Entity<Customer>().Property(c =>
             c.PhoneNo).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(c => c.City).HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(c =>
             c.District).HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(c => c.State).HasMaxLength(20);


            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);

            modelBuilder.Entity<Order>().Property(o =>
             o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Order>().Property(o =>
             o.OrderedItem).HasMaxLength(50);

            modelBuilder.Entity<Order>().HasRequired(c => c.Customer)
             .WithMany(o => o.Orders).HasForeignKey(o => o.CustomerId);
            //one to many
            modelBuilder.Entity<Order>()
            .HasRequired(c => c.Customer)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.CustomerId)
            .WillCascadeOnDelete(true);
            //many to many
            modelBuilder.Entity<Order>()
                .HasMany(c => c.Products)
                .WithMany(t => t.Orders)
                 .Map(m =>
                 {
                     m.MapLeftKey("ProductRefId");
                     m.MapRightKey("OrderRefId");
                     m.ToTable("OrderCourseNew");
                 });


            //one to one
            base.OnModelCreating(modelBuilder);

        }
    }
}
