﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SergRasKoin.Storage.DataBase;

#nullable disable

namespace SergRasKoin.Storage.MS_SQL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240514185837_Added course")]
    partial class Addedcourse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SergRasKoin.Storage.Models.Course", b =>
                {
                    b.Property<Guid>("Isnnode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("course")
                        .HasColumnType("bigint");

                    b.Property<string>("dateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Isnnode");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SergRasKoin.Storage.Models.Sales", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Count_Of_Coins")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IsnNode");

                    b.HasIndex("UserId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("SergRasKoin.Storage.Models.User", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IsnNode");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SergRasKoin.Storage.Models.Sales", b =>
                {
                    b.HasOne("SergRasKoin.Storage.Models.User", "User")
                        .WithMany("Sale")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SergRasKoin.Storage.Models.User", b =>
                {
                    b.Navigation("Sale");
                });
#pragma warning restore 612, 618
        }
    }
}
