using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LjubavNaPmfu.Baza
{
    public partial class ljubavContext : DbContext
    {
        public ljubavContext()
        {
        }

        public ljubavContext(DbContextOptions<ljubavContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hobi> Hobi { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KorisnikHobiji> KorisnikHobiji { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0ST8JT7\\SQLEXPRESS2019;Initial Catalog=ljubav;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobi>(entity =>
            {
                entity.HasKey(e => e.IdH);

                entity.Property(e => e.IdH).HasColumnName("id_h");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasColumnName("lozinka")
                    .HasMaxLength(10);

                entity.Property(e => e.Mobitel).HasMaxLength(20);

                entity.Property(e => e.Omeni)
                    .HasColumnName("OMeni")
                    .HasMaxLength(30);

                entity.Property(e => e.Role).HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<KorisnikHobiji>(entity =>
            {
                entity.HasKey(e => new { e.IdP, e.IdH });

                entity.ToTable("Korisnik_hobiji");

                entity.Property(e => e.IdP).HasColumnName("id_p");

                entity.Property(e => e.IdH).HasColumnName("id_h");

                entity.HasOne(d => d.IdHNavigation)
                    .WithMany(p => p.KorisnikHobiji)
                    .HasForeignKey(d => d.IdH)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_hobiji_Hobi");

                entity.HasOne(d => d.IdPNavigation)
                    .WithMany(p => p.KorisnikHobiji)
                    .HasForeignKey(d => d.IdP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_hobiji_Korisnik");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
