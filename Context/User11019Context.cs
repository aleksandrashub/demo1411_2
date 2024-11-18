using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demo1411shubenok.Models;

namespace demo1411shubenok.Context;

public partial class User11019Context : DbContext
{
    public User11019Context()
    {
    }

    public User11019Context(DbContextOptions<User11019Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categ> Categs { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Cust> Custs { get; set; }

    public virtual DbSet<EdIzm> EdIzms { get; set; }

    public virtual DbSet<Manuf> Manufs { get; set; }

    public virtual DbSet<Prod> Prods { get; set; }

    public virtual DbSet<Punkt> Punkts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    public virtual DbSet<ZakazPr> ZakazPrs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159;Database=user11019;Username=user11019;Password=16527");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categ>(entity =>
        {
            entity.HasKey(e => e.IdCateg).HasName("categ_pk");

            entity.ToTable("categ", "demo1411");

            entity.Property(e => e.IdCateg)
                .ValueGeneratedNever()
                .HasColumnName("id_categ");
            entity.Property(e => e.Categ1)
                .HasColumnType("character varying")
                .HasColumnName("categ");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("client_pk");

            entity.ToTable("client", "demo1411");

            entity.Property(e => e.IdClient)
                .ValueGeneratedNever()
                .HasColumnName("id_client");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Passwd)
                .HasColumnType("character varying")
                .HasColumnName("passwd");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("client_roles_fk");
        });

        modelBuilder.Entity<Cust>(entity =>
        {
            entity.HasKey(e => e.IdCust).HasName("cust_pk");

            entity.ToTable("cust", "demo1411");

            entity.Property(e => e.IdCust)
                .ValueGeneratedNever()
                .HasColumnName("id_cust");
            entity.Property(e => e.Cust1)
                .HasColumnType("character varying")
                .HasColumnName("cust");
        });

        modelBuilder.Entity<EdIzm>(entity =>
        {
            entity.HasKey(e => e.IdEdIzm).HasName("ed_izm_pk");

            entity.ToTable("ed_izm", "demo1411");

            entity.Property(e => e.IdEdIzm)
                .ValueGeneratedNever()
                .HasColumnName("id_ed_izm");
            entity.Property(e => e.EdIzm1)
                .HasColumnType("character varying")
                .HasColumnName("ed_izm");
        });

        modelBuilder.Entity<Manuf>(entity =>
        {
            entity.HasKey(e => e.IdManuf).HasName("manuf_pk");

            entity.ToTable("manuf", "demo1411");

            entity.Property(e => e.IdManuf)
                .ValueGeneratedNever()
                .HasColumnName("id_manuf");
            entity.Property(e => e.Manuf1)
                .HasColumnType("character varying")
                .HasColumnName("manuf");
        });

        modelBuilder.Entity<Prod>(entity =>
        {
            entity.HasKey(e => e.IdProd).HasName("prod_pk");

            entity.ToTable("prod", "demo1411");

            entity.Property(e => e.IdProd)
                .ValueGeneratedNever()
                .HasColumnName("id_prod");
            entity.Property(e => e.Articul)
                .HasColumnType("character varying")
                .HasColumnName("articul");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.CurrDisc).HasColumnName("curr_disc");
            entity.Property(e => e.Descr)
                .HasColumnType("character varying")
                .HasColumnName("descr");
            entity.Property(e => e.IdCateg).HasColumnName("id_categ");
            entity.Property(e => e.IdCust).HasColumnName("id_cust");
            entity.Property(e => e.IdEdIzm).HasColumnName("id_ed_izm");
            entity.Property(e => e.IdMan).HasColumnName("id_man");
            entity.Property(e => e.Image)
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.MaxDisc).HasColumnName("max_disc");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.QuanSkl).HasColumnName("quan_skl");

            entity.HasOne(d => d.IdCategNavigation).WithMany(p => p.Prods)
                .HasForeignKey(d => d.IdCateg)
                .HasConstraintName("prod_categ_fk");

            entity.HasOne(d => d.IdCustNavigation).WithMany(p => p.Prods)
                .HasForeignKey(d => d.IdCust)
                .HasConstraintName("prod_cust_fk");

            entity.HasOne(d => d.IdEdIzmNavigation).WithMany(p => p.Prods)
                .HasForeignKey(d => d.IdEdIzm)
                .HasConstraintName("prod_ed_izm_fk");

            entity.HasOne(d => d.IdManNavigation).WithMany(p => p.Prods)
                .HasForeignKey(d => d.IdMan)
                .HasConstraintName("prod_manuf_fk");
        });

        modelBuilder.Entity<Punkt>(entity =>
        {
            entity.HasKey(e => e.IdPunkt).HasName("punkt_pk");

            entity.ToTable("punkt", "demo1411");

            entity.Property(e => e.IdPunkt)
                .ValueGeneratedNever()
                .HasColumnName("id_punkt");
            entity.Property(e => e.Punkt1)
                .HasColumnType("character varying")
                .HasColumnName("punkt");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("roles_pk");

            entity.ToTable("roles", "demo1411");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("id_role");
            entity.Property(e => e.Role1)
                .HasColumnType("character varying")
                .HasColumnName("role");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("status_pk");

            entity.ToTable("status", "demo1411");

            entity.Property(e => e.IdStatus)
                .ValueGeneratedNever()
                .HasColumnName("id_status");
            entity.Property(e => e.Status1)
                .HasColumnType("character varying")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.HasKey(e => e.IdZakaz).HasName("zakaz_pk");

            entity.ToTable("zakaz", "demo1411");

            entity.Property(e => e.IdZakaz)
                .ValueGeneratedNever()
                .HasColumnName("id_zakaz");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DateCr).HasColumnName("date_cr");
            entity.Property(e => e.DeteDeliv).HasColumnName("dete_deliv");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdPunkt).HasColumnName("id_punkt");
            entity.Property(e => e.IdStat).HasColumnName("id_stat");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("zakaz_client_fk");

            entity.HasOne(d => d.IdPunktNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.IdPunkt)
                .HasConstraintName("zakaz_punkt_fk");

            entity.HasOne(d => d.IdStatNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.IdStat)
                .HasConstraintName("zakaz_status_fk");
        });

        modelBuilder.Entity<ZakazPr>(entity =>
        {
            entity.HasKey(e => new { e.IdZakaz, e.IdProd }).HasName("zakaz_pr_pk");

            entity.ToTable("zakaz_pr", "demo1411");

            entity.Property(e => e.IdZakaz).HasColumnName("id_zakaz");
            entity.Property(e => e.IdProd).HasColumnName("id_prod");
            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.ZakazPrs)
                .HasForeignKey(d => d.IdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zakaz_pr_prod_fk");

            entity.HasOne(d => d.IdZakazNavigation).WithMany(p => p.ZakazPrs)
                .HasForeignKey(d => d.IdZakaz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zakaz_pr_zakaz_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
