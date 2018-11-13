using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

namespace IMDBxApp.Models
{
    public partial class IMDBxContext : DbContext
    {
        private const string connectionStr = "Server=.\\SQLEXPRESS;Database=IMDBx;Trusted_Connection=True;";
        public IMDBxContext()
        {
        }

        public IMDBxContext(DbContextOptions<IMDBxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActorMaster> ActorMaster { get; set; }
        public virtual DbSet<MovieActorDb> MovieActorDb { get; set; }
        public virtual DbSet<MovieMaster> MovieMaster { get; set; }
        public virtual DbSet<ProducerMaster> ProducerMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               optionsBuilder.UseSqlServer(connectionStr);
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

            modelBuilder.Entity<MovieActorDb>(entity =>
            {
                entity.ToTable("movie_actor_db");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActorId)
                    .HasColumnName("actor_id")
                    .HasMaxLength(10);

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .HasMaxLength(10);
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
