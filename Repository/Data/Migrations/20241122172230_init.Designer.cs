﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20241122172230_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChoiceTaxt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("Core.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Core.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("MaxDuration")
                        .HasColumnType("int");

                    b.Property<int>("PassMark")
                        .HasColumnType("int");

                    b.Property<int>("TotalGrade")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Core.Models.ExamQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamQuestion");
                });

            modelBuilder.Entity("Core.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Core.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Core.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Core.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateOnly>("BarthDate")
                        .HasColumnType("date");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Core.Models.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DeletedOn")
                        .HasColumnType("date");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UpdetedOn")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("Core.Models.Choice", b =>
                {
                    b.HasOne("Core.Models.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Core.Models.Course", b =>
                {
                    b.HasOne("Core.Models.Instructor", null)
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId");
                });

            modelBuilder.Entity("Core.Models.Exam", b =>
                {
                    b.HasOne("Core.Models.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseId");

                    b.HasOne("Core.Models.Instructor", "Instructor")
                        .WithMany("Exams")
                        .HasForeignKey("InstructorId");

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Core.Models.ExamQuestion", b =>
                {
                    b.HasOne("Core.Models.Exam", "Exam")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Question", "Question")
                        .WithMany("QuetionExams")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Exam");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Core.Models.Question", b =>
                {
                    b.HasOne("Core.Models.Instructor", "Instructor")
                        .WithMany("Questions")
                        .HasForeignKey("InstructorId");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Core.Models.Result", b =>
                {
                    b.HasOne("Core.Models.Exam", "Exam")
                        .WithMany("Results")
                        .HasForeignKey("ExamId");

                    b.HasOne("Core.Models.Student", "Student")
                        .WithOne("Result")
                        .HasForeignKey("Core.Models.Result", "StudentId");

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Core.Models.StudentCourse", b =>
                {
                    b.HasOne("Core.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId");

                    b.HasOne("Core.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Core.Models.Course", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("Exams");
                });

            modelBuilder.Entity("Core.Models.Exam", b =>
                {
                    b.Navigation("ExamQuestions");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("Core.Models.Instructor", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Exams");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Core.Models.Question", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("QuetionExams");
                });

            modelBuilder.Entity("Core.Models.Student", b =>
                {
                    b.Navigation("Result")
                        .IsRequired();

                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}