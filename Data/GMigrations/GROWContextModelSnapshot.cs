﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PinewoodGrow.Data;

namespace PinewoodGrow.Data.GMigrations
{
    [DbContext(typeof(GROWContext))]
    partial class GROWContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21");

            modelBuilder.Entity("PinewoodGrow.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(150);

                    b.Property<double?>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double?>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("PlaceID")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PinewoodGrow.Models.Dietary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Dietaries");
                });

            modelBuilder.Entity("PinewoodGrow.Models.FileContent", b =>
                {
                    b.Property<int>("FileContentID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("FileContentID");

                    b.ToTable("FileContent");
                });

            modelBuilder.Entity("PinewoodGrow.Models.Gender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("PinewoodGrow.Models.GroceryStore", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullAddress")
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("GroceryStores");
                });

            modelBuilder.Entity("PinewoodGrow.Models.Household", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dependants")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilySize")
                        .HasColumnType("INTEGER");

                    b.Property<double>("HouseIncome")
                        .HasColumnType("REAL");

                    b.Property<bool>("LICO")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.ToTable("Households");
                });

            modelBuilder.Entity("PinewoodGrow.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompletedBy")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CompletedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Consent")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("GenderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseholdID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Income")
                        .HasColumnType("REAL");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.HasKey("ID");

                    b.HasIndex("GenderID");

                    b.HasIndex("HouseholdID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberDietary", b =>
                {
                    b.Property<int>("DietaryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberID")
                        .HasColumnType("INTEGER");

                    b.HasKey("DietaryID", "MemberID");

                    b.HasIndex("MemberID");

                    b.ToTable("MemberDietaries");
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberHousehold", b =>
                {
                    b.Property<int>("MemberID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseholdID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MemberID", "HouseholdID");

                    b.HasIndex("HouseholdID");

                    b.ToTable("MemberHouseholds");
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberSituation", b =>
                {
                    b.Property<int>("SituationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SituationID", "MemberID");

                    b.HasIndex("MemberID");

                    b.ToTable("MemberSituations");
                });

            modelBuilder.Entity("PinewoodGrow.Models.Situation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Situations");
                });

            modelBuilder.Entity("PinewoodGrow.Models.TravelDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("GroceryBike")
                        .HasColumnType("REAL");

                    b.Property<double>("GroceryDistance")
                        .HasColumnType("REAL");

                    b.Property<double>("GroceryDrive")
                        .HasColumnType("REAL");

                    b.Property<string>("GroceryID")
                        .HasColumnType("TEXT");

                    b.Property<double>("GroceryWalk")
                        .HasColumnType("REAL");

                    b.Property<double>("GrowBike")
                        .HasColumnType("REAL");

                    b.Property<double>("GrowDistance")
                        .HasColumnType("REAL");

                    b.Property<double>("GrowDrive")
                        .HasColumnType("REAL");

                    b.Property<double>("GrowWalk")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("AddressID")
                        .IsUnique();

                    b.HasIndex("GroceryID");

                    b.ToTable("TravelDetails");
                });

            modelBuilder.Entity("PinewoodGrow.Models.UploadedFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("UploadedFiles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UploadedFile");
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberDocument", b =>
                {
                    b.HasBaseType("PinewoodGrow.Models.UploadedFile");

                    b.Property<int>("MemberID")
                        .HasColumnType("INTEGER");

                    b.HasIndex("MemberID");

                    b.HasDiscriminator().HasValue("MemberDocument");
                });

            modelBuilder.Entity("PinewoodGrow.Models.FileContent", b =>
                {
                    b.HasOne("PinewoodGrow.Models.UploadedFile", "UploadedFile")
                        .WithOne("FileContent")
                        .HasForeignKey("PinewoodGrow.Models.FileContent", "FileContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PinewoodGrow.Models.Household", b =>
                {
                    b.HasOne("PinewoodGrow.Models.Address", "Address")
                        .WithMany("Households")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PinewoodGrow.Models.Member", b =>
                {
                    b.HasOne("PinewoodGrow.Models.Gender", "Gender")
                        .WithMany("Members")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PinewoodGrow.Models.Household", "Household")
                        .WithMany("Members")
                        .HasForeignKey("HouseholdID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberDietary", b =>
                {
                    b.HasOne("PinewoodGrow.Models.Dietary", "Dietary")
                        .WithMany("MemberDietaries")
                        .HasForeignKey("DietaryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PinewoodGrow.Models.Member", "Member")
                        .WithMany("MemberDietaries")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberHousehold", b =>
                {
                    b.HasOne("PinewoodGrow.Models.Household", "Household")
                        .WithMany("MemberHouseholds")
                        .HasForeignKey("HouseholdID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PinewoodGrow.Models.Member", "Member")
                        .WithMany("MemberHouseholds")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberSituation", b =>
                {
                    b.HasOne("PinewoodGrow.Models.Member", "Member")
                        .WithMany("MemberSituations")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PinewoodGrow.Models.Situation", "Situation")
                        .WithMany("MemberSituations")
                        .HasForeignKey("SituationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PinewoodGrow.Models.TravelDetail", b =>
                {
                    b.HasOne("PinewoodGrow.Models.Address", "Address")
                        .WithOne("TravelDetail")
                        .HasForeignKey("PinewoodGrow.Models.TravelDetail", "AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PinewoodGrow.Models.GroceryStore", "GroceryStore")
                        .WithMany("TravelDetails")
                        .HasForeignKey("GroceryID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PinewoodGrow.Models.MemberDocument", b =>
                {
                    b.HasOne("PinewoodGrow.Models.Member", "Member")
                        .WithMany("MemberDocuments")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
