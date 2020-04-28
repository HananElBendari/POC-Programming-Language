﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POC.Programming.Infrastructure.Persistence;

namespace POC.Programming.Infrastructure.Migrations
{
    [DbContext(typeof(ProgrammingContext))]
    [Migration("20200425220805_remove")]
    partial class remove
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POC.Programming.Domain.Entities.ProgrammingCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProgrammingCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProgrammingCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingCategory");
                });

            modelBuilder.Entity("POC.Programming.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfHits")
                        .HasColumnType("int");

                    b.Property<int>("ProgrammingCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("ProgrammingLanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingCategoryId");

                    b.ToTable("ProgrammingLanguage");
                });

            modelBuilder.Entity("POC.Programming.Domain.Entities.ProgrammingLanguageDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Like")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProgrammingLanguageDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("ProgrammingLanguageDetails");
                });

            modelBuilder.Entity("POC.Programming.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.HasOne("POC.Programming.Domain.Entities.ProgrammingCategory", "ProgrammingCategory")
                        .WithMany("ProgrammingLanguages")
                        .HasForeignKey("ProgrammingCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("POC.Programming.Domain.Entities.ProgrammingLanguageDetails", b =>
                {
                    b.HasOne("POC.Programming.Domain.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("ProgrammingLanguageDetails")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
