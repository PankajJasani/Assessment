using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Assessment.DataAccessLayer.Models
{
    public partial class AssessmentDBContext : DbContext
    {
        public AssessmentDBContext()
        {
        }

        public AssessmentDBContext(DbContextOptions<AssessmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsCity> AsCities { get; set; }
        public virtual DbSet<AsPerson> AsPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
             //   optionsBuilder.UseSqlServer("Server=.;Database=AssessmentDB;Trusted_Connection=true;User Id=sa;Password=jasani;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("AsCity");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'A')");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AsPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("AsPerson");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'A')");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AsPeople)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_AsPerson_AsCity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
