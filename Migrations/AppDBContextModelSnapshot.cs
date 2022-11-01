﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NghiaVoBlog.Data;

#nullable disable

namespace NghiaVoBlog.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NghiaVoBlog.Models.Article", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ViewCount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("CategoryID");

                    b.ToTable("tblArticle", (string)null);
                });

            modelBuilder.Entity("NghiaVoBlog.Models.ArticleLiker", b =>
                {
                    b.Property<Guid>("ArticleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArticleID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("ArticleLiker", (string)null);
                });

            modelBuilder.Entity("NghiaVoBlog.Models.ArticleTag", b =>
                {
                    b.Property<Guid>("ArticleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArticleID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("tblArticleTag", (string)null);
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CreatedById");

                    b.ToTable("tblCategory", (string)null);
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ArticleID");

                    b.HasIndex("AuthorID");

                    b.ToTable("tblComment", (string)null);
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Tag", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TblTag", (string)null);
                });

            modelBuilder.Entity("NghiaVoBlog.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("tblUser", (string)null);
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Article", b =>
                {
                    b.HasOne("NghiaVoBlog.Models.User", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NghiaVoBlog.Models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.ArticleLiker", b =>
                {
                    b.HasOne("NghiaVoBlog.Models.Article", "Article")
                        .WithMany("ArticleLikers")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NghiaVoBlog.Models.User", "User")
                        .WithMany("ArticleLikers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.ArticleTag", b =>
                {
                    b.HasOne("NghiaVoBlog.Models.Article", "Article")
                        .WithMany("ArticleTags")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NghiaVoBlog.Models.Tag", "Tag")
                        .WithMany("ArticleTags")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Category", b =>
                {
                    b.HasOne("NghiaVoBlog.Models.User", "CreatedBy")
                        .WithMany("Categories")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Comment", b =>
                {
                    b.HasOne("NghiaVoBlog.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NghiaVoBlog.Models.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Article", b =>
                {
                    b.Navigation("ArticleLikers");

                    b.Navigation("ArticleTags");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.Tag", b =>
                {
                    b.Navigation("ArticleTags");
                });

            modelBuilder.Entity("NghiaVoBlog.Models.User", b =>
                {
                    b.Navigation("ArticleLikers");

                    b.Navigation("Articles");

                    b.Navigation("Categories");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
