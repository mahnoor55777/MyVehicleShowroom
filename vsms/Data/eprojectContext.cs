using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using vsms.Models;

namespace vsms.Data
{
    public partial class eprojectContext : DbContext
    {
        public eprojectContext()
        {
        }

        public eprojectContext(DbContextOptions<eprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyVehicle> CompanyVehicles { get; set; } = null!;
        public virtual DbSet<CustomerOrderItem> CustomerOrderItems { get; set; } = null!;
        public virtual DbSet<DealerCustomerPurchase> DealerCustomerPurchases { get; set; } = null!;
        public virtual DbSet<NewVehicle> NewVehicles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TblCheckout> TblCheckouts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=eproject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyVehicle>(entity =>
            {
                entity.ToTable("CompanyVehicle");

                entity.Property(e => e.CompanyVehicleBrand)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleColour)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleModelNum)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(800)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .HasName("PK__customer__41E3D8EED65A7A11");

                entity.ToTable("customer_order_items");

                entity.Property(e => e.OrderItemId).HasColumnName("Order_item_ID");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CustomerOrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__customer___order__2F10007B");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.CustomerOrderItems)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__customer___vehic__300424B4");
            });

            modelBuilder.Entity<DealerCustomerPurchase>(entity =>
            {
                entity.HasKey(e => e.DcpId)
                    .HasName("PK__Dealer_C__5F1082E2C2A7547A");

                entity.ToTable("Dealer_Customer_Purchase");

                entity.Property(e => e.DcpId).HasColumnName("DCP_ID");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("date")
                    .HasColumnName("date_of_purchase");

                entity.Property(e => e.TotaleOrderPrice).HasColumnName("Totale_Order_Price");

                entity.Property(e => e.UId).HasColumnName("U_ID");

                entity.HasOne(d => d.UIdNavigation)
                    .WithMany(p => p.DealerCustomerPurchases)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__Dealer_Cus__U_ID__30F848ED");
            });

            modelBuilder.Entity<NewVehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.ToTable("New_Vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_Id");

                entity.Property(e => e.CompanyVehicleBrand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleColour)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleModelNum)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyVehicleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("Role");

                entity.Property(e => e.Rname)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCheckout>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("tbl_checkout");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderDate)
                    .IsUnicode(false)
                    .HasColumnName("order_date");

                entity.Property(e => e.UserId)
                    .IsUnicode(false)
                    .HasColumnName("user_id");

                entity.Property(e => e.VNo)
                    .IsUnicode(false)
                    .HasColumnName("v_no");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserCity)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhoneNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.RolesNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roles)
                    .HasConstraintName("FK__Users__Roles__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
