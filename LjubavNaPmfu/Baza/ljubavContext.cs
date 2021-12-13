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
        public virtual DbSet<Profil> Profil { get; set; }

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
                entity.HasKey(e => e.IdK)
                    .HasName("PK__Korisnik__9DB7D2FED1D4513D");

                entity.Property(e => e.IdK).HasColumnName("id_k");

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasColumnName("lozinka")
                    .HasMaxLength(20);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20);
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
                    .HasConstraintName("FK_Korisnik_hobiji_Profil");
            });

            modelBuilder.Entity<Profil>(entity =>
            {
                entity.HasKey(e => e.IdP);

                entity.Property(e => e.IdP).HasColumnName("id_p");

                entity.Property(e => e.IdK).HasColumnName("id_k");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OMeni)
                    .IsRequired()
                    .HasColumnName("O_meni")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdKNavigation)
                    .WithMany(p => p.Profil)
                    .HasForeignKey(d => d.IdK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profil_Korisnik");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
