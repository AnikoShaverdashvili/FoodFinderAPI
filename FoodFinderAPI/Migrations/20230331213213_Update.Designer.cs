﻿// <auto-generated />
using System;
using FoodFinderAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodFinderAPI.Migrations
{
    [DbContext(typeof(FoodFinderDbContext))]
    [Migration("20230331213213_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodFinderAPI.Models.Allergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Allergy", "fb");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredient", "fd");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meal", "fd");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.MealIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("MealId");

                    b.ToTable("MealIngredient", "fd");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AllergyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AllergyId");

                    b.ToTable("User", "fd");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.UserAllergy", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("AllergyId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AllergyId");

                    b.HasIndex("AllergyId");

                    b.ToTable("UserAllergy", "fd");
                });

            modelBuilder.Entity("MealIngredientAllergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AllergyId")
                        .HasColumnType("int");

                    b.Property<int>("MealIngredientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AllergyId");

                    b.HasIndex("MealIngredientId");

                    b.ToTable("MealIngredientAllergy");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.MealIngredient", b =>
                {
                    b.HasOne("FoodFinderAPI.Models.Ingredient", "Ingredient")
                        .WithMany("MealIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFinderAPI.Models.Meal", "Meal")
                        .WithMany("MealIngredients")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.User", b =>
                {
                    b.HasOne("FoodFinderAPI.Models.Allergy", null)
                        .WithMany("Users")
                        .HasForeignKey("AllergyId");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.UserAllergy", b =>
                {
                    b.HasOne("FoodFinderAPI.Models.Allergy", "Allergy")
                        .WithMany("UserAllergies")
                        .HasForeignKey("AllergyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFinderAPI.Models.User", "User")
                        .WithMany("UserAllergies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealIngredientAllergy", b =>
                {
                    b.HasOne("FoodFinderAPI.Models.Allergy", null)
                        .WithMany()
                        .HasForeignKey("AllergyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFinderAPI.Models.MealIngredient", null)
                        .WithMany()
                        .HasForeignKey("MealIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodFinderAPI.Models.Allergy", b =>
                {
                    b.Navigation("UserAllergies");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.Ingredient", b =>
                {
                    b.Navigation("MealIngredients");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.Meal", b =>
                {
                    b.Navigation("MealIngredients");
                });

            modelBuilder.Entity("FoodFinderAPI.Models.User", b =>
                {
                    b.Navigation("UserAllergies");
                });
#pragma warning restore 612, 618
        }
    }
}
