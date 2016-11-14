using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Zza.Data;

namespace Zza.Data.Migrations
{
    [DbContext(typeof(ZzaDbContext))]
    partial class ZzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Zza.Data.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<Guid?>("StoreId");

                    b.Property<string>("Street");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Zza.Data.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<decimal>("DeliveryCharge");

                    b.Property<string>("DeliveryCity");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<string>("DeliveryState");

                    b.Property<string>("DeliveryStreet");

                    b.Property<string>("DeliveryZip");

                    b.Property<decimal>("ItemsTotal");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderStatusId");

                    b.Property<string>("Phone");

                    b.Property<Guid?>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Zza.Data.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instructions");

                    b.Property<long>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("ProductSizeId");

                    b.Property<int>("Quantity");

                    b.Property<Guid?>("StoreId");

                    b.Property<decimal>("TotalPrice");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductSizeId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Zza.Data.OrderItemOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("OrderItemId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductOptionId");

                    b.Property<int>("Quantity");

                    b.Property<Guid?>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("OrderItemId");

                    b.HasIndex("ProductOptionId");

                    b.ToTable("OrderItemOptions");
                });

            modelBuilder.Entity("Zza.Data.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("Zza.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("HasOptions");

                    b.Property<string>("Image");

                    b.Property<bool>("IsVegetarian");

                    b.Property<string>("Name");

                    b.Property<string>("SizeIds");

                    b.Property<string>("Type");

                    b.Property<bool>("WithTomatoSauce");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Zza.Data.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Factor");

                    b.Property<bool>("IsPizzaOption");

                    b.Property<bool>("IsSaladOption");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("ProductOptions");
                });

            modelBuilder.Entity("Zza.Data.ProductSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("IsGlutenFree");

                    b.Property<string>("Name");

                    b.Property<decimal?>("PremiumPrice");

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("ToppingPrice");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("ProductSizes");
                });

            modelBuilder.Entity("Zza.Data.Order", b =>
                {
                    b.HasOne("Zza.Data.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zza.Data.OrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Zza.Data.OrderItem", b =>
                {
                    b.HasOne("Zza.Data.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zza.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zza.Data.ProductSize", "Size")
                        .WithMany()
                        .HasForeignKey("ProductSizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Zza.Data.OrderItemOption", b =>
                {
                    b.HasOne("Zza.Data.OrderItem", "OrderItem")
                        .WithMany("Options")
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zza.Data.ProductOption", "ProductOption")
                        .WithMany()
                        .HasForeignKey("ProductOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
