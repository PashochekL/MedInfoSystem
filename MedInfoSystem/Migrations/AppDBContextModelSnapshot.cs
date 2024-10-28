﻿// <auto-generated />
using System;
using MedInfoSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedInfoSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid?>("ConsultationId")
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

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("LastVisitDate")
                        .HasColumnType("timestamp with time zone");

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
                            Id = new Guid("3978d566-0b3d-41c9-a7d3-e66b45e4ee78"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3972),
                            Name = "Акушер-гинеколог"
                        },
                        new
                        {
                            Id = new Guid("a3aa605c-6cb8-4ac7-bf27-825895c09d76"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3975),
                            Name = "Анестезиолог-реаниматолог"
                        },
                        new
                        {
                            Id = new Guid("5afc931c-0e53-49f1-a557-e93014e1d9fd"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3978),
                            Name = "Дерматовенеролог"
                        },
                        new
                        {
                            Id = new Guid("0ef08c0f-2fb6-4421-bc5c-1b04e440d493"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3980),
                            Name = "Инфекционист"
                        },
                        new
                        {
                            Id = new Guid("60414cd9-d659-4179-9927-dcdb3a52f751"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3982),
                            Name = "Кардиолог"
                        },
                        new
                        {
                            Id = new Guid("e58f0b4e-7ecb-4c21-9eb3-743df55b97e7"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3983),
                            Name = "Невролог"
                        },
                        new
                        {
                            Id = new Guid("830feb82-62fc-4b04-a14a-6e74ab554a63"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3985),
                            Name = "Онколог"
                        },
                        new
                        {
                            Id = new Guid("f6792a9d-c5ba-459d-b4c8-192664abdcac"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3999),
                            Name = "Ортопед"
                        },
                        new
                        {
                            Id = new Guid("c5da51ef-a960-49bd-b2b1-fe8cbb397487"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4000),
                            Name = "Педиатр"
                        },
                        new
                        {
                            Id = new Guid("a3fa2b54-e5d4-481f-aa6e-579606f45de5"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4002),
                            Name = "Ревматолог"
                        },
                        new
                        {
                            Id = new Guid("1c3ec727-2086-45fd-a1b1-8703e2513f3b"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4003),
                            Name = "Стоматолог"
                        },
                        new
                        {
                            Id = new Guid("b8052338-3bc9-4cb4-8bec-548e17bf6a1b"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4005),
                            Name = "Хирург"
                        },
                        new
                        {
                            Id = new Guid("8c000e9f-f950-47e7-aa00-e90c05d4167e"),
                            CreateTime = new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4007),
                            Name = "Эндокринолог"
                        });
                });

            modelBuilder.Entity("MedInfoSystem.Data.Entities.Comment", b =>
                {
                    b.HasOne("MedInfoSystem.Data.Entities.Doctor", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedInfoSystem.Data.Entities.Consultation", null)
                        .WithMany("RootComment")
                        .HasForeignKey("ConsultationId");

                    b.Navigation("Author");
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
