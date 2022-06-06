﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TermProject;

#nullable disable

namespace TermProject.Migrations
{
    [DbContext(typeof(DiceShopContext))]
    [Migration("20220606135442_DiceBase")]
    partial class DiceBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("TermProject.Clients", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ACC_Creation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Full_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TermProject.Employees", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Employed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Employee_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TermProject.OrderItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrdersID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("OrdersID");

                    b.HasIndex("ProductsID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("TermProject.Orders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientsID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeesID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("status")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ClientsID");

                    b.HasIndex("EmployeesID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TermProject.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Product_Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Product_Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SellingSince")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TermProject.OrderItems", b =>
                {
                    b.HasOne("TermProject.Orders", "Orders")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrdersID");

                    b.HasOne("TermProject.Products", "Products")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductsID");

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TermProject.Orders", b =>
                {
                    b.HasOne("TermProject.Clients", "Clients")
                        .WithMany("Orders")
                        .HasForeignKey("ClientsID");

                    b.HasOne("TermProject.Employees", "Employees")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeesID");

                    b.Navigation("Clients");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("TermProject.Clients", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TermProject.Employees", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TermProject.Orders", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("TermProject.Products", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
