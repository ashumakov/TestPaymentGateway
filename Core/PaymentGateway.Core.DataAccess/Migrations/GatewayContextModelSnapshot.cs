﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentGateway.Core.DataAccess.Context;

namespace PaymentGateway.Core.DataAccess.Migrations
{
    [DbContext(typeof(GatewayContext))]
    partial class GatewayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("PaymentGateway.Core.DataAccess.Models.Merchant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SigningKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Merchants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("daf008ed-beff-44c0-a67b-f256e650fe5f"),
                            BankAccountNumber = "11111111111111111111111",
                            Description = "Shop that provides some good",
                            Name = "Test merchant",
                            SigningKey = "Q#!SIPYCGOzcUGqDhMWAMizy9Wb9lt"
                        });
                });

            modelBuilder.Entity("PaymentGateway.Core.DataAccess.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAuthCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankStatusCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankTansactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("PaymentGateway.Core.DataAccess.Models.Payment", b =>
                {
                    b.HasOne("PaymentGateway.Core.DataAccess.Models.Merchant", "Owner")
                        .WithMany("Payments")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PaymentGateway.Core.DataAccess.Models.Merchant", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
