using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using pgSQL.Models;

namespace pgSQL.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20170701031046_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("pgSQL.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnName("url")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("blog");
                });

            modelBuilder.Entity("pgSQL.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id");

                    b.Property<int?>("Duration")
                        .HasColumnName("duration");

                    b.Property<string>("Genre")
                        .HasColumnName("genre")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasName("movies_title_key");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("pgSQL.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Blogid")
                        .HasColumnName("blogid");

                    b.Property<string>("Content")
                        .HasColumnName("content")
                        .HasColumnType("varchar")
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Blogid");

                    b.ToTable("post");
                });

            modelBuilder.Entity("pgSQL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnName("birthday")
                        .HasColumnType("date");

                    b.Property<string>("BlogSiteUrl")
                        .HasColumnName("blog_site_url")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("pgSQL.Models.Post", b =>
                {
                    b.HasOne("pgSQL.Models.Blog", "Blog")
                        .WithMany("Post")
                        .HasForeignKey("Blogid")
                        .HasConstraintName("post_blogid_fkey");
                });
        }
    }
}
