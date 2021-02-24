﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WESTDemo.Infrastracture.Context;

namespace WESTDemo.Infrastracture.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20210223072258_AddUpdateEntities")]
    partial class AddUpdateEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WESTDemo.Domain.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Learner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Learner");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.LearnerGroup", b =>
                {
                    b.Property<int>("LearnerId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("LearnerId", "GroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("LearnerId")
                        .IsUnique();

                    b.ToTable("LearnerGroup");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.LearnerStatus", b =>
                {
                    b.Property<int>("LearnerId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("LearnerId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("LearnerStatus");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("src.WESTDemo.Domain.Models.Centre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Centre");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Learner", b =>
                {
                    b.HasOne("WESTDemo.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.LearnerGroup", b =>
                {
                    b.HasOne("WESTDemo.Domain.Models.Group", "Group")
                        .WithMany("LearnerGroups")
                        .HasForeignKey("GroupId")
                        .IsRequired();

                    b.HasOne("WESTDemo.Domain.Models.Learner", "Learner")
                        .WithOne("LearnerGroup")
                        .HasForeignKey("WESTDemo.Domain.Models.LearnerGroup", "LearnerId")
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.LearnerStatus", b =>
                {
                    b.HasOne("WESTDemo.Domain.Models.Course", "Course")
                        .WithMany("LearnerCourses")
                        .HasForeignKey("CourseId")
                        .IsRequired();

                    b.HasOne("WESTDemo.Domain.Models.Learner", "Learner")
                        .WithMany("LearnerCourses")
                        .HasForeignKey("LearnerId")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.User", b =>
                {
                    b.HasOne("WESTDemo.Domain.Models.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .IsRequired();

                    b.HasOne("WESTDemo.Domain.Models.UserType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("src.WESTDemo.Domain.Models.Centre", b =>
                {
                    b.HasOne("WESTDemo.Domain.Models.Organisation", "Organisation")
                        .WithMany("Centres")
                        .HasForeignKey("OrganisationId")
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Course", b =>
                {
                    b.Navigation("LearnerCourses");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Group", b =>
                {
                    b.Navigation("LearnerGroups");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Learner", b =>
                {
                    b.Navigation("LearnerCourses");

                    b.Navigation("LearnerGroup");
                });

            modelBuilder.Entity("WESTDemo.Domain.Models.Organisation", b =>
                {
                    b.Navigation("Centres");
                });
#pragma warning restore 612, 618
        }
    }
}
