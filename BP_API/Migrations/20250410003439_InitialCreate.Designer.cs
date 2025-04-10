﻿// <auto-generated />
using System;
using BP_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BP_API.Migrations
{
    [DbContext(typeof(LogContext))]
    [Migration("20250410003439_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("BP_API.Models.Measurement", b =>
                {
                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Diagnosis")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Diastolic")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Systolic")
                        .HasColumnType("INTEGER");

                    b.HasKey("Date");

                    b.ToTable("measurements");
                });
#pragma warning restore 612, 618
        }
    }
}
