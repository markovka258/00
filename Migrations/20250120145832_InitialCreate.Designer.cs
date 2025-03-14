﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkCalendar.Data;

#nullable disable

namespace WorkCalendar.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250120145832_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("WorkCalendar.Data.Holiday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HolidayDate")
                        .HasColumnType("TEXT");

                    b.HasKey("HolidayId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("WorkCalendar.Data.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShiftId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RequestId");

                    b.HasIndex("ShiftId")
                        .IsUnique();

                    b.HasIndex("WorkerId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("WorkCalendar.Data.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("ScheduleId");

                    b.HasIndex("EmployerId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("WorkCalendar.Data.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ShiftId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("WorkCalendar.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkCalendar.Data.Request", b =>
                {
                    b.HasOne("WorkCalendar.Data.Shift", "Shift")
                        .WithOne("Request")
                        .HasForeignKey("WorkCalendar.Data.Request", "ShiftId");

                    b.HasOne("WorkCalendar.Data.User", "Worker")
                        .WithMany("Requests")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shift");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("WorkCalendar.Data.Schedule", b =>
                {
                    b.HasOne("WorkCalendar.Data.User", "Employer")
                        .WithMany("Schedules")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("WorkCalendar.Data.Shift", b =>
                {
                    b.HasOne("WorkCalendar.Data.Schedule", "Schedule")
                        .WithMany("Shifts")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkCalendar.Data.User", "Worker")
                        .WithMany("Shifts")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("WorkCalendar.Data.Schedule", b =>
                {
                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("WorkCalendar.Data.Shift", b =>
                {
                    b.Navigation("Request");
                });

            modelBuilder.Entity("WorkCalendar.Data.User", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("Schedules");

                    b.Navigation("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
