using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AmuletPJ01.Models
{
    public partial class AmuletturtleContext : DbContext
    {
        public AmuletturtleContext()
        {
        }

        public AmuletturtleContext(DbContextOptions<AmuletturtleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdmin> TbAdmin { get; set; }
        public virtual DbSet<TbAmulet> TbAmulet { get; set; }
        public virtual DbSet<TbManual> TbManual { get; set; }
        public virtual DbSet<TbMonk> TbMonk { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L0LHLEC\\MSSQLSERVER14;Initial Catalog=AmuletTurtle;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAmulet>(entity =>
            {
                entity.HasKey(e => e.AmuletId);

                entity.Property(e => e.AmuletId).HasColumnName("AmuletID");

                entity.Property(e => e.Generation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManualId).HasColumnName("ManualID");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manual)
                    .WithMany(p => p.TbAmulet)
                    .HasForeignKey(d => d.ManualId)
                    .HasConstraintName("FK_TbAmulet_TbManual");
            });

            modelBuilder.Entity<TbManual>(entity =>
            {
                entity.HasKey(e => e.ManualId);

                entity.Property(e => e.ManualId).HasColumnName("ManualID");

                entity.Property(e => e.Picture2).HasColumnType("image");
            });

            modelBuilder.Entity<TbMonk>(entity =>
            {
                entity.HasKey(e => e.MonkId);

                entity.Property(e => e.MonkId).HasColumnName("MonkID");

                entity.Property(e => e.Picture3).HasColumnType("image");

                entity.Property(e => e.Story).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
