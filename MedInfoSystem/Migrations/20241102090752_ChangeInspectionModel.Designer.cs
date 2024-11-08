﻿// <auto-generated />
using System;
using MedInfoSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedInfoSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241102090752_ChangeInspectionModel")]
    partial class ChangeInspectionModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConsultationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ConsultationId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Consultation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CommentsNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("InspectionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("InspectionId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Diagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("InspectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InspectionId");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.ICD", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Actual")
                        .HasColumnType("integer");

                    b.Property<int?>("AdditionalCode")
                        .HasColumnType("integer");

                    b.Property<string>("CodeICD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<string>("FieldSort")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("UniqueIdentifier")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ICDs");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Inspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Anamnesis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("BaseInspectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Conclusion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("NextVisitDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PreviousInspectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Inspections");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.RevokedToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RevokedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RevokedTokens");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3199b206-9bba-4a79-95ee-7f5df580efda"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2522),
                            Name = "Акушер-гинеколог"
                        },
                        new
                        {
                            Id = new Guid("d4d931c6-bd21-44f3-8e65-b47d96e05338"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2532),
                            Name = "Анестезиолог-реаниматолог"
                        },
                        new
                        {
                            Id = new Guid("ac77e905-0fb9-4d79-95ca-944003a48855"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2535),
                            Name = "Дерматовенеролог"
                        },
                        new
                        {
                            Id = new Guid("e1ec8704-e3f0-4022-a338-8daaf0d801f9"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2538),
                            Name = "Инфекционист"
                        },
                        new
                        {
                            Id = new Guid("4260350c-b147-4bf6-96d0-8af304cfdffe"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2540),
                            Name = "Кардиолог"
                        },
                        new
                        {
                            Id = new Guid("235072f7-ce29-45e4-93e5-e5f398b70a5f"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2542),
                            Name = "Невролог"
                        },
                        new
                        {
                            Id = new Guid("cdea51e1-2d5e-43e6-ae58-2ecfae981e9f"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2562),
                            Name = "Онколог"
                        },
                        new
                        {
                            Id = new Guid("3d963c65-1839-448f-8290-d52e0c9785fa"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2565),
                            Name = "Ортопед"
                        },
                        new
                        {
                            Id = new Guid("60e25948-6d19-428b-87a0-1daeb51241e9"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2567),
                            Name = "Педиатр"
                        },
                        new
                        {
                            Id = new Guid("c8796829-7df1-4b23-8de4-6967935819b1"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2569),
                            Name = "Ревматолог"
                        },
                        new
                        {
                            Id = new Guid("5fef6ca1-4f3a-4274-b6fb-b0969e6dd26b"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2572),
                            Name = "Стоматолог"
                        },
                        new
                        {
                            Id = new Guid("265f0b6d-83f5-4e57-acd0-cac9c5a9d70d"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2574),
                            Name = "Хирург"
                        },
                        new
                        {
                            Id = new Guid("73d26c1c-fdc2-434d-b89c-3835b19e2684"),
                            CreateTime = new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2576),
                            Name = "Эндокринолог"
                        });
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Comment", b =>
                {
                    b.HasOne("MedInfoSystem.Data.Entities.Doctor", "Author")
                        .WithMany("comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedInfoSystem.Data.Entities.Consultation", "Consultation")
                        .WithMany("RootComment")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Consultation");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Consultation", b =>
                {
                    b.HasOne("MedInfoSystem.Data.Entities.Inspection", "Inspection")
                        .WithMany("Consultations")
                        .HasForeignKey("InspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedInfoSystem.Data.Entities.Speciality", "Speciality")
                        .WithMany("Consultation")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inspection");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Diagnosis", b =>
                {
                    b.HasOne("MedInfoSystem.Data.Entities.Inspection", "Inspection")
                        .WithMany("Diagnoses")
                        .HasForeignKey("InspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inspection");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Doctor", b =>
                {
                    b.HasOne("MedInfoSystem.Data.Entities.Speciality", "speciality")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("speciality");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Inspection", b =>
                {
                    b.HasOne("MedInfoSystem.Data.Entities.Doctor", "Doctor")
                        .WithMany("Inspection")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedInfoSystem.Data.Entities.Patient", "Patient")
                        .WithMany("Inspection")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Consultation", b =>
                {
                    b.Navigation("RootComment");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Doctor", b =>
                {
                    b.Navigation("Inspection");

                    b.Navigation("comments");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Inspection", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("Diagnoses");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Patient", b =>
                {
                    b.Navigation("Inspection");
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Speciality", b =>
                {
                    b.Navigation("Consultation");

                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}