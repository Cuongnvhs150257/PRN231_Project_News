using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_API.Models
{
    public partial class PRN_ProjectContext : DbContext
    {
        public PRN_ProjectContext()
        {
        }

        public PRN_ProjectContext(DbContextOptions<PRN_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conf.GetConnectionString("PRN_Project"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasColumnName("edit_date");

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Summary)
                    .HasMaxLength(255)
                    .HasColumnName("summary");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.View).HasColumnName("view");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articles_User");

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Articles)
                    .UsingEntity<Dictionary<string, object>>(
                        "ArticlesCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Articles_Categories_Categories"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("ArticleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Articles_Categories_Articles"),
                        j =>
                        {
                            j.HasKey("ArticleId", "CategoryId");

                            j.ToTable("Articles_Categories");

                            j.IndexerProperty<int>("ArticleId").HasColumnName("article_id");

                            j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                        });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
