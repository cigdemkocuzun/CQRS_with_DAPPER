﻿// <auto-generated />
using System;
using Albelli.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Albelli.Infrastructure.Migrations
{
    [DbContext(typeof(OrdersContext))]
    partial class OrdersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Albelli.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("_email")
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("_welcomeEmailWasSent")
                        .HasColumnName("WelcomeEmailWasSent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Customers","orders");
                });

            modelBuilder.Entity("Albelli.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PackageWidth")
                        .HasColumnType("float");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products","orders");
                });

            modelBuilder.Entity("Albelli.Infrastructure.Processing.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InternalCommands","app");
                });

            modelBuilder.Entity("Albelli.Infrastructure.Processing.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages","app");
                });

            modelBuilder.Entity("Albelli.Domain.Customers.Customer", b =>
                {
                    b.OwnsMany("Albelli.Domain.Orders.Order", "_orders", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModifiedOn")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("_isRemoved")
                                .HasColumnName("IsRemoved")
                                .HasColumnType("bit");

                            b1.Property<DateTime?>("_orderChangeDate")
                                .HasColumnName("OrderChangeDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("_orderDate")
                                .HasColumnName("OrderDate")
                                .HasColumnType("datetime2");

                            b1.Property<double>("_requiredBinWidth")
                                .HasColumnName("RequiredBinWidth")
                                .HasColumnType("float");

                            b1.Property<byte>("_status")
                                .HasColumnName("StatusId")
                                .HasColumnType("tinyint");

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Orders","orders");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.OwnsMany("Albelli.Domain.Orders.OrderProduct", "_orderProducts", b2 =>
                                {
                                    b2.Property<Guid>("OrderId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("ProductId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("CreatedBy")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<DateTime>("CreatedOn")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("LastModifiedBy")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<DateTime?>("LastModifiedOn")
                                        .HasColumnType("datetime2");

                                    b2.Property<int>("Quantity")
                                        .HasColumnType("int");

                                    b2.HasKey("OrderId", "ProductId");

                                    b2.HasIndex("ProductId");

                                    b2.ToTable("OrderProducts","orders");

                                    b2.WithOwner()
                                        .HasForeignKey("OrderId");

                                    b2.HasOne("Albelli.Domain.Products.Product", "Product")
                                        .WithMany()
                                        .HasForeignKey("ProductId")
                                        .OnDelete(DeleteBehavior.Cascade)
                                        .IsRequired();

                                    b2.OwnsOne("Albelli.Domain.SharedKernel.MoneyValue", "Value", b3 =>
                                        {
                                            b3.Property<Guid>("OrderProductOrderId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<Guid>("OrderProductProductId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<string>("Currency")
                                                .HasColumnName("Currency")
                                                .HasColumnType("nvarchar(max)");

                                            b3.Property<decimal>("Value")
                                                .HasColumnName("Value")
                                                .HasColumnType("decimal(18,2)");

                                            b3.HasKey("OrderProductOrderId", "OrderProductProductId");

                                            b3.ToTable("OrderProducts");

                                            b3.WithOwner()
                                                .HasForeignKey("OrderProductOrderId", "OrderProductProductId");
                                        });

                                    b2.OwnsOne("Albelli.Domain.SharedKernel.MoneyValue", "ValueInEUR", b3 =>
                                        {
                                            b3.Property<Guid>("OrderProductOrderId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<Guid>("OrderProductProductId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<string>("Currency")
                                                .HasColumnName("CurrencyEUR")
                                                .HasColumnType("nvarchar(max)");

                                            b3.Property<decimal>("Value")
                                                .HasColumnName("ValueInEUR")
                                                .HasColumnType("decimal(18,2)");

                                            b3.HasKey("OrderProductOrderId", "OrderProductProductId");

                                            b3.ToTable("OrderProducts");

                                            b3.WithOwner()
                                                .HasForeignKey("OrderProductOrderId", "OrderProductProductId");
                                        });
                                });

                            b1.OwnsOne("Albelli.Domain.SharedKernel.MoneyValue", "_value", b2 =>
                                {
                                    b2.Property<Guid>("OrderId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Currency")
                                        .HasColumnName("Currency")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<decimal>("Value")
                                        .HasColumnName("Value")
                                        .HasColumnType("decimal(18,2)");

                                    b2.HasKey("OrderId");

                                    b2.ToTable("Orders");

                                    b2.WithOwner()
                                        .HasForeignKey("OrderId");
                                });
                        });
                });

            modelBuilder.Entity("Albelli.Domain.Products.Product", b =>
                {
                    b.OwnsMany("Albelli.Domain.Products.ProductPrice", "_prices", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Currency")
                                .HasColumnType("varchar(3)");

                            b1.HasKey("ProductId", "Currency");

                            b1.ToTable("ProductPrices","orders");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");

                            b1.OwnsOne("Albelli.Domain.SharedKernel.MoneyValue", "Value", b2 =>
                                {
                                    b2.Property<Guid>("ProductPriceProductId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("ProductPriceCurrency")
                                        .HasColumnType("varchar(3)");

                                    b2.Property<string>("Currency")
                                        .IsRequired()
                                        .HasColumnName("Currency")
                                        .HasColumnType("varchar(3)");

                                    b2.Property<decimal>("Value")
                                        .HasColumnName("Value")
                                        .HasColumnType("decimal(18,2)");

                                    b2.HasKey("ProductPriceProductId", "ProductPriceCurrency");

                                    b2.ToTable("ProductPrices");

                                    b2.WithOwner()
                                        .HasForeignKey("ProductPriceProductId", "ProductPriceCurrency");
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
