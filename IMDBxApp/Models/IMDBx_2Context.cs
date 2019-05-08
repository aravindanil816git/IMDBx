using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMDBxApp.Models
{
    public partial class IMDBx_2Context : DbContext
    {
        public IMDBx_2Context()
        {
        }

        public IMDBx_2Context(DbContextOptions<IMDBx_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ActorMaster> ActorMaster { get; set; }
        public virtual DbSet<CastingDetails> CastingDetails { get; set; }
        public virtual DbSet<MovieMaster> MovieMaster { get; set; }
        public virtual DbSet<ProducerMaster> ProducerMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=IMDBx_2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMaster>(entity =>
            {
                entity.HasKey(e => e.ActorId);

                entity.ToTable("actor_master");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasColumnName("actor_name");

                entity.Property(e => e.Bio).HasColumnType("text");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CastingDetails>(entity =>
            {
                entity.ToTable("casting_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");
            });

            modelBuilder.Entity<MovieMaster>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.ToTable("movie_master");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("movie_name");

                entity.Property(e => e.Plot)
                    .HasColumnName("plot")
                    .HasColumnType("text");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ReleaseYear)
                    .HasColumnName("release_year")
                    .HasColumnType("date");

                entity.Property(e => e.Thumbnail)
                    .HasColumnName("thumbnail")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<ProducerMaster>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.ToTable("producer_master");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Bio)
                    .HasColumnName("bio")
                    .HasColumnType("text");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasColumnName("prod_name");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(10);
            });
        }
    }
}
