using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Webshop.Models
{
    public partial class webshopContext : DbContext
    {
        public webshopContext()
        {
        }

        public webshopContext(DbContextOptions<webshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<StockBalance> StockBalances { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:newtonwebshop.database.windows.net,1433;Initial Catalog=webshop;Persist Security Info=False;User ID=webshopAdmin;Password=very%secure%password%for%a%database00;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerIdFK");

                entity.HasOne(d => d.PaymentDetail)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PaymentDetailIdFK");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ShippingMethodIdFK");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderIdFK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderDetailProductIdFK");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("value");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PaymentMethodIdFK");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("smallmoney");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryIdFK");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SupplierIdFK");
            });

            modelBuilder.Entity<ShippingMethod>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<StockBalance>(entity =>
            {
                entity.HasKey(e => e.StockBalance1)
                    .HasName("PK__StockBal__DFC03EE2E14B252F");

                entity.ToTable("StockBalance");

                entity.Property(e => e.StockBalance1).HasColumnName("StockBalance");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StockBalances)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductIdFK");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("salt");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
