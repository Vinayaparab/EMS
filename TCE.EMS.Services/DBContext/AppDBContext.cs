using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TCE.EMS.Services.EFModels;

namespace TCE.EMS.Services.DBContext;

public partial class AppDBContext : DbContext
{
     public AppDBContext() {}
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CfgAppConfig> CfgAppConfigs { get; set; }

    public virtual DbSet<TblCurrency> TblCurrencies { get; set; }

    public virtual DbSet<TblEmp> TblEmps { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUserAcl> TblUserAcls { get; set; }

    public virtual DbSet<TblUserToken> TblUserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CfgAppConfig>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cfg_AppConfig", "Config");

            entity.Property(e => e.InternetUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("InternetURL");
            entity.Property(e => e.IntranetUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("IntranetURL");
            entity.Property(e => e.MobAppCurrVerNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MobAppCurrVerNoIOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MobAppCurrVerNo_iOS");
            entity.Property(e => e.MobAppLink)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MobAppLinkIOs)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MobAppLink_iOS");
            entity.Property(e => e.MobIntranetUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MobIntranetURL");
            entity.Property(e => e.SmtpAuthType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SMTP_AuthType");
            entity.Property(e => e.SmtpIpaddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SMTP_IPAddress");
            entity.Property(e => e.SmtpName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SMTP_Name");
            entity.Property(e => e.SmtpPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SMTP_Password");
            entity.Property(e => e.SmtpPort).HasColumnName("SMTP_Port");
            entity.Property(e => e.SmtpSendMail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SMTP_SendMail");
            entity.Property(e => e.SmtpSendUsing)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SMTP_SendUsing");
            entity.Property(e => e.SmtpUser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SMTP_User");
            entity.Property(e => e.SystemEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<TblCurrency>(entity =>
        {
            entity.HasKey(e => e.DocId).HasName("PK__tbl_Curr__3EF1888D01C80BA8");

            entity.ToTable("tbl_Currency", "Masters");

            entity.Property(e => e.DocId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("DocID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("_CreatedBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("_CreatedOn");
            entity.Property(e => e.CurrCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CurrName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.IsAdvance)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.LmodBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("_LModBy");
            entity.Property(e => e.LmodOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("_LModOn");
            entity.Property(e => e.OrderNo).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<TblEmp>(entity =>
        {
            entity.HasKey(e => e.EmpCode).HasName("PK__tbl_Emp__7DA847CB626DFD26");

            entity.ToTable("tbl_Emp", "Masters");

            entity.Property(e => e.EmpCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("_CreatedBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("_CreatedOn");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.LmodBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("_LModBy");
            entity.Property(e => e.LmodOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("_LModOn");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleCode).HasName("PK__tbl_Role__D62CB59D4A40544A");

            entity.ToTable("tbl_Roles", "Masters");

            entity.Property(e => e.RoleCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("_CreatedBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("_CreatedOn");
            entity.Property(e => e.LmodBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("_LModBy");
            entity.Property(e => e.LmodOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("_LModOn");
            entity.Property(e => e.RoleDesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<TblUserAcl>(entity =>
        {
            entity.HasKey(e => e.UserAclid).HasName("PK__tbl_User__94317ECE535418F5");

            entity.ToTable("tbl_UserACL", "Masters");

            entity.Property(e => e.UserAclid).HasColumnName("UserACLId");
            entity.Property(e => e.Aclcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ACLCode");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.RoleCode)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<TblUserToken>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_User_token", "MOB");

            entity.Property(e => e.EmpCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Key).IsUnicode(false);
            entity.Property(e => e.MobAppVerNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SessionUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.SrNo).ValueGeneratedOnAdd();
            entity.Property(e => e.TokenUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserToken).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
