﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NailsAPI.Entities;

namespace NailsAPI.Migrations
{
    [DbContext(typeof(NailsDbContext))]
    [Migration("20220116195856_ColumnRefactor3")]
    partial class ColumnRefactor3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("NailsAPI.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("NailsAPI.Entities.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("ProcedureDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcedureEstimatedTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcedureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcedurePrice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("NailsAPI.Entities.Procedure", b =>
                {
                    b.HasOne("NailsAPI.Entities.Appointment", null)
                        .WithMany("Procedures")
                        .HasForeignKey("AppointmentId");
                });

            modelBuilder.Entity("NailsAPI.Entities.Appointment", b =>
                {
                    b.Navigation("Procedures");
                });
#pragma warning restore 612, 618
        }
    }
}