﻿// <auto-generated />
using System;
using AGAT.LocoDispatcher.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200729070957_initMigration")]
    partial class initMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Carriage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RailId")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RailId")
                        .IsUnique();

                    b.ToTable("Carriages");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Coord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RailId")
                        .HasColumnType("int");

                    b.Property<int?>("RoutePlateId")
                        .HasColumnType("int");

                    b.Property<bool>("StartFlag")
                        .HasColumnType("bit");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RailId");

                    b.HasIndex("RoutePlateId");

                    b.ToTable("Coords");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Locomotive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Angle")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locomotives");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Angle")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Rail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.Property<string>("RailCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParkId");

                    b.ToTable("Rails");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.RoutePlate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Angle")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RailId")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RailId")
                        .IsUnique();

                    b.ToTable("RoutePlates");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Stations.Park", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Stations.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Carriage", b =>
                {
                    b.HasOne("AGAT.LocoDispatcher.Data.Models.Rails.Rail", "Rail")
                        .WithOne("Carriage")
                        .HasForeignKey("AGAT.LocoDispatcher.Data.Models.Rails.Carriage", "RailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Coord", b =>
                {
                    b.HasOne("AGAT.LocoDispatcher.Data.Models.Rails.Rail", "Rail")
                        .WithMany("Coords")
                        .HasForeignKey("RailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AGAT.LocoDispatcher.Data.Models.Rails.RoutePlate", "RoutePlate")
                        .WithMany()
                        .HasForeignKey("RoutePlateId");
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Point", b =>
                {
                    b.HasOne("AGAT.LocoDispatcher.Data.Models.Stations.Park", "Park")
                        .WithMany()
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.Rail", b =>
                {
                    b.HasOne("AGAT.LocoDispatcher.Data.Models.Stations.Park", "Park")
                        .WithMany("Rails")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Rails.RoutePlate", b =>
                {
                    b.HasOne("AGAT.LocoDispatcher.Data.Models.Rails.Rail", "Rail")
                        .WithOne("RoutePlate")
                        .HasForeignKey("AGAT.LocoDispatcher.Data.Models.Rails.RoutePlate", "RailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGAT.LocoDispatcher.Data.Models.Stations.Park", b =>
                {
                    b.HasOne("AGAT.LocoDispatcher.Data.Models.Stations.Station", null)
                        .WithMany("Parks")
                        .HasForeignKey("StationId");
                });
#pragma warning restore 612, 618
        }
    }
}
