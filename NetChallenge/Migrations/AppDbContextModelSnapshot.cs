﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetChallenge.Data;

#nullable disable

namespace NetChallenge.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("NetChallenge.Domain.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OfficeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OfficeLocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("OfficeId", "LocationId");

                    b.HasIndex("OfficeId", "OfficeLocationId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("NetChallenge.Domain.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("OfficeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId", "LocationId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("NetChallenge.Domain.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("NetChallenge.Domain.Office", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id", "LocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("NetChallenge.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NetChallenge.Domain.Booking", b =>
                {
                    b.HasOne("NetChallenge.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetChallenge.Domain.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId", "LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NetChallenge.Domain.Office", null)
                        .WithMany("Bookings")
                        .HasForeignKey("OfficeId", "OfficeLocationId");

                    b.Navigation("Office");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetChallenge.Domain.Facility", b =>
                {
                    b.HasOne("NetChallenge.Domain.Office", "Office")
                        .WithMany("Facilities")
                        .HasForeignKey("OfficeId", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("NetChallenge.Domain.Office", b =>
                {
                    b.HasOne("NetChallenge.Domain.Location", "Location")
                        .WithMany("Offices")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("NetChallenge.Domain.Location", b =>
                {
                    b.Navigation("Offices");
                });

            modelBuilder.Entity("NetChallenge.Domain.Office", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Facilities");
                });
#pragma warning restore 612, 618
        }
    }
}
