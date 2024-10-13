using System;
using System.Collections.Generic;
using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse;

public partial class JjhKioskDbContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public JjhKioskDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public virtual DbSet<KioskAccount> KioskAccounts { get; set; }

    public virtual DbSet<KioskList> KioskLists { get; set; }

    public virtual DbSet<KioskMenuCategory> KioskMenuCategories { get; set; }

    public virtual DbSet<KioskMenuList> KioskMenuLists { get; set; }

    public virtual DbSet<KioskMenuOptionGroup> KioskMenuOptionGroups { get; set; }

    public virtual DbSet<KioskMenuOptionMember> KioskMenuOptionMembers { get; set; }

    public virtual DbSet<KioskMenuOptionType> KioskMenuOptionTypes { get; set; }

    public virtual DbSet<KioskMenuType> KioskMenuTypes { get; set; }

    public virtual DbSet<KioskOrder> KioskOrders { get; set; }

    public virtual DbSet<KioskOrderCart> KioskOrderCarts { get; set; }

    public virtual DbSet<KioskOrderLog> KioskOrderLogs { get; set; }

    public virtual DbSet<KioskOrderStatusType> KioskOrderStatusTypes { get; set; }

    public virtual DbSet<KioskStoreList> KioskStoreLists { get; set; }

    public virtual DbSet<KioskStoreType> KioskStoreTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.0.12;port=3307;database=JJH_KioskDB;user=jjh;password=wngudA3@y7j70", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.6-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<KioskAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("Kiosk_Account");

            entity.HasIndex(e => e.StoreId, "Kiosk_Account_Kiosk_StoreList_FK");

            entity.HasIndex(e => e.UserName, "Kiosk_Account_UNIQUE").IsUnique();

            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Salt).HasMaxLength(255);
            entity.Property(e => e.StoreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("StoreID");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Store).WithMany(p => p.KioskAccounts)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("Kiosk_Account_Kiosk_StoreList_FK");
        });

        modelBuilder.Entity<KioskList>(entity =>
        {
            entity.HasKey(e => e.KioskId).HasName("PRIMARY");

            entity.ToTable("Kiosk_List");

            entity.HasIndex(e => e.StoreId, "Kiosk_List_Kiosk_StoreList_FK");

            entity.Property(e => e.KioskId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("KioskID");
            entity.Property(e => e.InstallDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.KioskName).HasMaxLength(20);
            entity.Property(e => e.StoreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("StoreID");

            entity.HasOne(d => d.Store).WithMany(p => p.KioskLists)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Kiosk_List_Kiosk_StoreList_FK");
        });

        modelBuilder.Entity<KioskMenuCategory>(entity =>
        {
            entity.HasKey(e => e.MenuCategoryId).HasName("PRIMARY");

            entity.ToTable("Kiosk_MenuCategory");

            entity.HasIndex(e => e.StoreId, "Kiosk_MenuCategory_Kiosk_StoreList_FK");

            entity.Property(e => e.MenuCategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("MenuCategoryID");
            entity.Property(e => e.MenuCategoryName).HasMaxLength(20);
            entity.Property(e => e.StoreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("StoreID");

            entity.HasOne(d => d.Store).WithMany(p => p.KioskMenuCategories)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("Kiosk_MenuCategory_Kiosk_StoreList_FK");
        });

        modelBuilder.Entity<KioskMenuList>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PRIMARY");

            entity.ToTable("Kiosk_MenuList");

            entity.HasIndex(e => e.MenuTypeId, "Kiosk_MenuList_Kiosk_MenuType_FK");

            entity.HasIndex(e => e.StoreId, "Kiosk_MenuList_Kiosk_StoreList_FK");

            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("MenuID");
            entity.Property(e => e.MenuName).HasMaxLength(50);
            entity.Property(e => e.MenuTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("MenuTypeID");
            entity.Property(e => e.Price).HasColumnType("int(10) unsigned");
            entity.Property(e => e.StoreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("StoreID");

            entity.HasOne(d => d.MenuType).WithMany(p => p.KioskMenuLists)
                .HasForeignKey(d => d.MenuTypeId)
                .HasConstraintName("Kiosk_MenuList_Kiosk_MenuType_FK");

            entity.HasOne(d => d.Store).WithMany(p => p.KioskMenuLists)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("Kiosk_MenuList_Kiosk_StoreList_FK");
        });

        modelBuilder.Entity<KioskMenuOptionGroup>(entity =>
        {
            entity.HasKey(e => e.OptionGroupId).HasName("PRIMARY");

            entity.ToTable("Kiosk_MenuOptionGroup");

            entity.HasIndex(e => e.OptionTypeId, "Kiosk_MenuOptionGroup_Kiosk_MenuOptionType_FK");

            entity.HasIndex(e => e.MenuTypeId, "Kiosk_MenuOptionGroup_Kiosk_MenuType_FK");

            entity.Property(e => e.OptionGroupId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("OptionGroupID");
            entity.Property(e => e.MenuTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("MenuTypeID");
            entity.Property(e => e.OptionGroupName).HasMaxLength(50);
            entity.Property(e => e.OptionTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("OptionTypeID");

            entity.HasOne(d => d.MenuType).WithMany(p => p.KioskMenuOptionGroups)
                .HasForeignKey(d => d.MenuTypeId)
                .HasConstraintName("Kiosk_MenuOptionGroup_Kiosk_MenuType_FK");

            entity.HasOne(d => d.OptionType).WithMany(p => p.KioskMenuOptionGroups)
                .HasForeignKey(d => d.OptionTypeId)
                .HasConstraintName("Kiosk_MenuOptionGroup_Kiosk_MenuOptionType_FK");
        });

        modelBuilder.Entity<KioskMenuOptionMember>(entity =>
        {
            entity.HasKey(e => e.OptionMemberId).HasName("PRIMARY");

            entity.ToTable("Kiosk_MenuOptionMember");

            entity.HasIndex(e => e.OptionGroupId, "Kiosk_MenuOptionMember_Kiosk_MenuOptionGroup_FK");

            entity.Property(e => e.OptionMemberId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("OptionMemberID");
            entity.Property(e => e.OptionGroupId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("OptionGroupID");
            entity.Property(e => e.OptionMemberName).HasMaxLength(20);
            entity.Property(e => e.OptionMemberPrice).HasColumnType("int(10) unsigned");

            entity.HasOne(d => d.OptionGroup).WithMany(p => p.KioskMenuOptionMembers)
                .HasForeignKey(d => d.OptionGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Kiosk_MenuOptionMember_Kiosk_MenuOptionGroup_FK");
        });

        modelBuilder.Entity<KioskMenuOptionType>(entity =>
        {
            entity.HasKey(e => e.OptionTypeId).HasName("PRIMARY");

            entity.ToTable("Kiosk_MenuOptionType");

            entity.Property(e => e.OptionTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("OptionTypeID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.OptionTypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<KioskMenuType>(entity =>
        {
            entity.HasKey(e => e.MenuTypeId).HasName("PRIMARY");

            entity.ToTable("Kiosk_MenuType");

            entity.Property(e => e.MenuTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("MenuTypeID");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.MenuTypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<KioskOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("Kiosk_Order");

            entity.HasIndex(e => e.StatusTypeId, "Kiosk_Order_Kiosk_OrderStatusType_FK");

            entity.HasIndex(e => e.StoreId, "Kiosk_Order_Kiosk_StoreList_FK");

            entity.Property(e => e.OrderId)
                .HasMaxLength(23)
                .HasColumnName("OrderID");
            entity.Property(e => e.FullPrice).HasColumnType("int(10) unsigned");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.StatusTypeId)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("StatusTypeID");
            entity.Property(e => e.StoreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("StoreID");

            entity.HasOne(d => d.StatusType).WithMany(p => p.KioskOrders)
                .HasForeignKey(d => d.StatusTypeId)
                .HasConstraintName("Kiosk_Order_Kiosk_OrderStatusType_FK");

            entity.HasOne(d => d.Store).WithMany(p => p.KioskOrders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Kiosk_Order_Kiosk_StoreList_FK");
        });

        modelBuilder.Entity<KioskOrderCart>(entity =>
        {
            entity.HasKey(e => new { e.MenuOrder, e.OrderId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Kiosk_OrderCart");

            entity.HasIndex(e => e.MenuId, "Kiosk_OrderCart_Kiosk_MenuList_FK");

            entity.HasIndex(e => e.OrderId, "Kiosk_OrderCart_Kiosk_Order_FK");

            entity.Property(e => e.MenuOrder).HasColumnType("tinyint(3) unsigned");
            entity.Property(e => e.OrderId)
                .HasMaxLength(23)
                .HasColumnName("OrderID");
            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("MenuID");
            entity.Property(e => e.Qty).HasColumnType("smallint(5) unsigned");

            entity.HasOne(d => d.Menu).WithMany(p => p.KioskOrderCarts)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("Kiosk_OrderCart_Kiosk_MenuList_FK");

            entity.HasOne(d => d.Order).WithMany(p => p.KioskOrderCarts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Kiosk_OrderCart_Kiosk_Order_FK");
        });

        modelBuilder.Entity<KioskOrderLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_OrderLog");

            entity.HasIndex(e => e.StatusTypeId, "Kiosk_OrderLog_Kiosk_OrderStatusType_FK");

            entity.HasIndex(e => e.OrderId, "Kiosk_OrderLog_Kiosk_Order_FK");

            entity.Property(e => e.FullPrice).HasColumnType("int(11)");
            entity.Property(e => e.MenuDescription).HasMaxLength(200);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId)
                .HasMaxLength(23)
                .HasColumnName("OrderID");
            entity.Property(e => e.StatusTypeId)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("StatusTypeID");
            entity.Property(e => e.StoreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("StoreID");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("Kiosk_OrderLog_Kiosk_Order_FK");

            entity.HasOne(d => d.StatusType).WithMany()
                .HasForeignKey(d => d.StatusTypeId)
                .HasConstraintName("Kiosk_OrderLog_Kiosk_OrderStatusType_FK");
        });

        modelBuilder.Entity<KioskOrderStatusType>(entity =>
        {
            entity.HasKey(e => e.StatusTypeId).HasName("PRIMARY");

            entity.ToTable("Kiosk_OrderStatusType");

            entity.Property(e => e.StatusTypeId)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("StatusTypeID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.StatusTypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<KioskStoreList>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PRIMARY");

            entity.ToTable("Kiosk_StoreList");

            entity.HasIndex(e => e.StoreTypeNumber, "Kiosk_StoreList_Kiosk_StoreType_FK");

            entity.Property(e => e.StoreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("StoreID");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Owner).HasMaxLength(10);
            entity.Property(e => e.RegiDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.StoreName).HasMaxLength(20);
            entity.Property(e => e.StoreTypeNumber).HasColumnType("tinyint(4)");
            entity.Property(e => e.TelNumber).HasMaxLength(18);

            entity.HasOne(d => d.StoreTypeNumberNavigation).WithMany(p => p.KioskStoreLists)
                .HasForeignKey(d => d.StoreTypeNumber)
                .HasConstraintName("Kiosk_StoreList_Kiosk_StoreType_FK");
        });

        modelBuilder.Entity<KioskStoreType>(entity =>
        {
            entity.HasKey(e => e.StoreTypeNumber).HasName("PRIMARY");

            entity.ToTable("Kiosk_StoreType");

            entity.Property(e => e.StoreTypeNumber).HasColumnType("tinyint(4)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.StoreTypeName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
