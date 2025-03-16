using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProjectPRN212Group4.Models;

public partial class Prn212DbshopContext : DbContext
{
    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var connectionstring = configuration["ConnectionStrings:DefaultConnection"];
        return connectionstring;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    public Prn212DbshopContext()
    {
    }

    public Prn212DbshopContext(DbContextOptions<Prn212DbshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<TypeProduct> TypeProducts { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__AD0500869306AA6B");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.AdminName, "UQ__Admin__330679FEF49B9F80").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("adminID");
            entity.Property(e => e.AdminName)
                .HasMaxLength(255)
                .HasColumnName("adminName");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9DA1D02C16");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__4849DA0101119528").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__AB6E61649FA34B0D").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .HasColumnName("customerName");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__0809337D35347FAD");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discountAmount");
            entity.Property(e => e.FinalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("finalAmount");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("orderDate");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.VoucherId).HasColumnName("voucherID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__customer__47DBAE45");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Orders__voucherI__46E78A0C");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__E4FEDE2A3C76F28D");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("orderDetailID");
            entity.Property(e => e.DateOrder)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dateOrder");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__order__4BAC3F29");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__produ__4CA06362");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D14A492D5657");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .HasColumnName("colorName");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("productName");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SizeName)
                .HasMaxLength(50)
                .HasColumnName("sizeName");
            entity.Property(e => e.TypeId).HasColumnName("typeID");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Product__typeID__3A81B327");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__6465E19EA32E786D");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Staff__4849DA01901CC8C9").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Staff__AB6E6164F9FA948E").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("staffID");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.StaffName)
                .HasMaxLength(255)
                .HasColumnName("staffName");
        });

        modelBuilder.Entity<TypeProduct>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__TypeProd__F04DF11A1C791D39");

            entity.ToTable("TypeProduct");

            entity.Property(e => e.TypeId).HasColumnName("typeID");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .HasColumnName("typeName");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Vouchers__F5338989ABF32B9C");

            entity.HasIndex(e => e.VoucherCode, "UQ__Vouchers__09FEFFB0CF25F26D").IsUnique();

            entity.Property(e => e.VoucherId).HasColumnName("voucherID");
            entity.Property(e => e.MaxDiscountAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("maxDiscountAmount");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.ValidFrom).HasColumnName("validFrom");
            entity.Property(e => e.ValidUntil).HasColumnName("validUntil");
            entity.Property(e => e.VoucherCode)
                .HasMaxLength(50)
                .HasColumnName("voucherCode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
