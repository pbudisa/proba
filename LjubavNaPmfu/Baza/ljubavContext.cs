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

        public virtual DbSet<Blokirani> Blokirani { get; set; }
        public virtual DbSet<Hobi> Hobi { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KorisnikHobiji> KorisnikHobiji { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Odbijeni> Odbijeni { get; set; }
        public virtual DbSet<StudijskeGrupe> StudijskeGrupe { get; set; }

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
            modelBuilder.Entity<Blokirani>(entity =>
            {
                entity.HasKey(e => new { e.IdPrvi, e.IdDrugi });

                entity.Property(e => e.IdPrvi).HasColumnName("id_prvi");

                entity.Property(e => e.IdDrugi).HasColumnName("id_drugi");

                entity.HasOne(d => d.IdDrugiNavigation)
                    .WithMany(p => p.BlokiraniIdDrugiNavigation)
                    .HasForeignKey(d => d.IdDrugi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blokirani_Korisnik1");

                entity.HasOne(d => d.IdPrviNavigation)
                    .WithMany(p => p.BlokiraniIdPrviNavigation)
                    .HasForeignKey(d => d.IdPrvi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blokirani_Korisnik");
            });

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

                entity.Property(e => e.Ids).HasColumnName("ids");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasColumnName("lozinka")
                    .HasMaxLength(10);

                entity.Property(e => e.Mobitel).HasMaxLength(20);

                entity.Property(e => e.Omeni).HasColumnName("OMeni");

                entity.Property(e => e.Role).HasMaxLength(10);

                entity.Property(e => e.Spol).HasMaxLength(7);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(10);

                entity.Property(e => e.Zanimaju).HasMaxLength(7);

                entity.HasOne(d => d.IdsNavigation)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.Ids)
                    .HasConstraintName("FK_Korisnik_StudijskeGrupe");
            });

            modelBuilder.Entity<KorisnikHobiji>(entity =>
            {
                entity.HasKey(e => new { e.Idk, e.Idh });

                entity.ToTable("Korisnik_hobiji");

                entity.HasOne(d => d.IdhNavigation)
                    .WithMany(p => p.KorisnikHobiji)
                    .HasForeignKey(d => d.Idh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Korisnik_ho__Idh__756D6ECB");

                entity.HasOne(d => d.IdkNavigation)
                    .WithMany(p => p.KorisnikHobiji)
                    .HasForeignKey(d => d.Idk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Korisnik_ho__Idk__74794A92");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => new { e.IdPrvi, e.IdDrugi });

                entity.Property(e => e.IdPrvi).HasColumnName("id_prvi");

                entity.Property(e => e.IdDrugi).HasColumnName("id_drugi");

                entity.HasOne(d => d.IdDrugiNavigation)
                    .WithMany(p => p.MatchIdDrugiNavigation)
                    .HasForeignKey(d => d.IdDrugi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Korisnik1");

                entity.HasOne(d => d.IdPrviNavigation)
                    .WithMany(p => p.MatchIdPrviNavigation)
                    .HasForeignKey(d => d.IdPrvi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Korisnik");
            });

            modelBuilder.Entity<Odbijeni>(entity =>
            {
                entity.HasKey(e => new { e.IdPrvi, e.IdDrugi });

                entity.Property(e => e.IdPrvi).HasColumnName("id_prvi");

                entity.Property(e => e.IdDrugi).HasColumnName("id_drugi");

                entity.HasOne(d => d.IdDrugiNavigation)
                    .WithMany(p => p.OdbijeniIdDrugiNavigation)
                    .HasForeignKey(d => d.IdDrugi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Odbijeni_Korisnik1");

                entity.HasOne(d => d.IdPrviNavigation)
                    .WithMany(p => p.OdbijeniIdPrviNavigation)
                    .HasForeignKey(d => d.IdPrvi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Odbijeni_Korisnik");
            });

            modelBuilder.Entity<StudijskeGrupe>(entity =>
            {
                entity.HasKey(e => e.IdG)
                    .HasName("PK__Studijsk__DC501A29451CB796");

                entity.Property(e => e.IdG).HasColumnName("idG");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
