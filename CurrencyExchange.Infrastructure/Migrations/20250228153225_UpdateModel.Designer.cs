﻿// <auto-generated />
using System;
using CurrencyExchange.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurrencyExchange.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250228153225_UpdateModel")]
    partial class UpdateModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CurrencyExchange.Core.Enities.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourrencyId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CourrencyId");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("CurrencyExchange.Core.Enities.Currency", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Currencies", (string)null);
                });

            modelBuilder.Entity("CurrencyExchange.Core.Enities.ExchangeRate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("RateDate")
                        .HasColumnType("date");

                    b.HasKey("id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("ExchangeRates", (string)null);
                });

            modelBuilder.Entity("CurrencyExchange.Core.Enities.Country", b =>
                {
                    b.HasOne("CurrencyExchange.Core.Enities.Currency", "Currency")
                        .WithMany("Countries")
                        .HasForeignKey("CourrencyId");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CurrencyExchange.Core.Enities.ExchangeRate", b =>
                {
                    b.HasOne("CurrencyExchange.Core.Enities.Currency", "Currency")
                        .WithMany("Rates")
                        .HasForeignKey("CurrencyId");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CurrencyExchange.Core.Enities.Currency", b =>
                {
                    b.Navigation("Countries");

                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
