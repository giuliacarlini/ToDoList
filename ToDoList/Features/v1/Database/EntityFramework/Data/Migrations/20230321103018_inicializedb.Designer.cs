﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using ToDoList.Features.v1.Database.EntityFramework.Data;

#nullable disable

namespace ToDoList.features.v1.database.entityframework.data.migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230321103018_inicializedb")]
    partial class inicializedb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ToDoList.Features.v1.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("User_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("List");
                });

            modelBuilder.Entity("ToDoList.Features.v1.Models.ListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ListItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListItem_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("List_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("User_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ListItemId");

                    b.ToTable("ListItem");
                });

            modelBuilder.Entity("ToDoList.Features.v1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ToDoList.Features.v1.Models.ListItem", b =>
                {
                    b.HasOne("ToDoList.Features.v1.Models.ListItem", null)
                        .WithMany("ListItems")
                        .HasForeignKey("ListItemId");
                });

            modelBuilder.Entity("ToDoList.Features.v1.Models.ListItem", b =>
                {
                    b.Navigation("ListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
