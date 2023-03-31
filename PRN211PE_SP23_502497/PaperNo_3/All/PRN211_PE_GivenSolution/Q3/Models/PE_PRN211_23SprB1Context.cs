using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Q3.Models
{
    public partial class PE_PRN211_23SprB1Context : DbContext
    {
        public PE_PRN211_23SprB1Context()
        {
        }

        public PE_PRN211_23SprB1Context(DbContextOptions<PE_PRN211_23SprB1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Button> Buttons { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Textbox> Textboxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyContr"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Button>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("room");

                entity.Property(e => e.Schoolyear).HasColumnName("schoolyear");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.SchoolyearNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Schoolyear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_SchoolYear");
            });

            modelBuilder.Entity<SchoolYear>(entity =>
            {
                entity.ToTable("SchoolYear");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enddate)
                    .HasColumnType("date")
                    .HasColumnName("enddate");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("startdate");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("fullname");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sex");

                entity.HasMany(d => d.Classes)
                    .WithMany(p => p.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentClass",
                        l => l.HasOne<Class>().WithMany().HasForeignKey("Classid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Student_Class_Class"),
                        r => r.HasOne<Student>().WithMany().HasForeignKey("Studentid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Student_Class_Student"),
                        j =>
                        {
                            j.HasKey("Studentid", "Classid");

                            j.ToTable("Student_Class");

                            j.IndexerProperty<int>("Studentid").HasColumnName("studentid");

                            j.IndexerProperty<int>("Classid").HasColumnName("classid");
                        });
            });

            modelBuilder.Entity<Textbox>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Readonly).HasColumnName("readonly");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
