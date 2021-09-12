﻿// <auto-generated />
using System;
using HareketRehberi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HareketRehberiAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210912194725_Evaluation")]
    partial class Evaluation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("HareketRehberi.Domain.Models.Entities.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EvaluationName")
                        .HasColumnType("text");

                    b.Property<bool>("IsSurvey")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("HareketRehberi.Domain.Models.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LessonName")
                        .HasColumnType("text");

                    b.Property<bool>("ProgressiveRelaxationExercise")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("HareketRehberi.Domain.Models.Entities.LessonPdfFileRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("FileGuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonPdfFileRelations");
                });

            modelBuilder.Entity("HareketRehberi.Domain.Models.Entities.LessonSoundFileRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("FileGuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonSoundFileRelations");
                });

            modelBuilder.Entity("HareketRehberi.Domain.Models.Entities.SystemUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(4000)");

                    b.Property<byte[]>("PasswordKey")
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("HareketRehberi.Domain.Models.Entities.LessonPdfFileRelation", b =>
                {
                    b.HasOne("HareketRehberi.Domain.Models.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("HareketRehberi.Domain.Models.Entities.LessonSoundFileRelation", b =>
                {
                    b.HasOne("HareketRehberi.Domain.Models.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });
#pragma warning restore 612, 618
        }
    }
}
