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
                            Id = new Guid("f4bcb23e-68ef-47a6-be57-fe1d0931fbc7"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8503),
                            Name = "Акушер-гинеколог"
                        },
                        new
                        {
                            Id = new Guid("53f0a983-6bdb-41b1-b6c8-656c4afb5975"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8508),
                            Name = "Анестезиолог-реаниматолог"
                        },
                        new
                        {
                            Id = new Guid("a38a2838-8247-4d79-8499-9d009e80f2b8"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8511),
                            Name = "Дерматовенеролог"
                        },
                        new
                        {
                            Id = new Guid("8007162f-eec4-4683-a558-f317d100d3fc"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8513),
                            Name = "Инфекционист"
                        },
                        new
                        {
                            Id = new Guid("c4216c22-ed51-4670-ad20-d0305115d55c"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8515),
                            Name = "Кардиолог"
                        },
                        new
                        {
                            Id = new Guid("5e38d2d8-51e8-4d59-b11a-7bd2fe12d668"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8516),
                            Name = "Невролог"
                        },
                        new
                        {
                            Id = new Guid("16c8b249-3ce2-4dd4-acdf-48296bb2c63b"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8534),
                            Name = "Онколог"
                        },
                        new
                        {
                            Id = new Guid("1badb30c-f3a6-4641-ac56-eae08c35567a"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8536),
                            Name = "Ортопед"
                        },
                        new
                        {
                            Id = new Guid("a2f8289d-c805-44e4-90f0-649ec989428a"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8538),
                            Name = "Педиатр"
                        },
                        new
                        {
                            Id = new Guid("65a3b39b-1339-45e1-a6ef-8da8d8b25c83"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8539),
                            Name = "Ревматолог"
                        },
                        new
                        {
                            Id = new Guid("a35bf7a9-a6e3-4e8d-baa1-48048f238f11"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8541),
                            Name = "Стоматолог"
                        },
                        new
                        {
                            Id = new Guid("1e16056e-aff2-428b-b92e-c935f6648401"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8543),
                            Name = "Хирург"
                        },
                        new
                        {
                            Id = new Guid("6c50bc6c-1b01-4024-9f01-b2ba931c80be"),
                            CreateTime = new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8545),
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
