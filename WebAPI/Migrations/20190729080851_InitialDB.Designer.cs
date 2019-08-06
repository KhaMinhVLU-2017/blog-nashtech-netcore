﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppMeoContext))]
    [Migration("20190729080851_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Picture");

                    b.Property<string>("Sapo")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("crDate");

                    b.HasKey("BlogID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("WebAPI.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogID");

                    b.Property<string>("Content");

                    b.Property<int>("UserID");

                    b.Property<DateTime>("crDate");

                    b.HasKey("CommentID");

                    b.HasIndex("BlogID");

                    b.HasIndex("UserID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("WebAPI.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RoleID");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            Name = "Mod"
                        },
                        new
                        {
                            RoleID = 3,
                            Name = "Member"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fullname");

                    b.Property<string>("Password");

                    b.Property<int>("RoleID");

                    b.Property<string>("Username")
                        .HasMaxLength(20);

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebAPI.Models.Blog", b =>
                {
                    b.HasOne("WebAPI.Models.User", "Author")
                        .WithMany("Blog")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.Comment", b =>
                {
                    b.HasOne("WebAPI.Models.Blog", "Blog")
                        .WithMany("Comment")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany("Comment")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.HasOne("WebAPI.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
