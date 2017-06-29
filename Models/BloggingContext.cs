using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pgSQL.Models
{
    public partial class BloggingContext : DbContext
    {
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'public.promotions'. Please see the warning messages.

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //     optionsBuilder.UseNpgsql(@"Host=localhost;Database=Blogging;Username=postgres;Password=ChingHai99@");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("blog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("movies");

                entity.HasIndex(e => e.Title)
                    .HasName("movies_title_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Blogid).HasColumnName("blogid");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.Blogid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("post_blogid_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.BlogSiteUrl)
                    .HasColumnName("blog_site_url")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
            });
        }
    }
}