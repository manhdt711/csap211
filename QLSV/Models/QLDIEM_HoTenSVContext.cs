using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLSV.Models
{
    public partial class QLDIEM_HoTenSVContext : DbContext
    {
        public QLDIEM_HoTenSVContext()
        {
        }

        public QLDIEM_HoTenSVContext(DbContextOptions<QLDIEM_HoTenSVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDiemSv> TblDiemSvs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=QLDIEM_HoTenSV;User Id=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblDiemSv>(entity =>
            {
                entity.ToTable("tblDiemSV");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiemChuyenCan).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemCuoiKy).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemGiuaKy).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(50)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.TenSv)
                    .HasMaxLength(100)
                    .HasColumnName("TenSV");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
