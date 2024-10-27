using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MedInfoSystem.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet <Inspection> Inspections { get; set; }

        public DbSet<Consultation> Consultations { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<RevokedToken> RevokedTokens { get; set; }

        public DbSet<ICD> ICDs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .Property(d => d.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Patient>()
                .Property(d => d.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Speciality>().HasData(
                new Speciality { Id = Guid.NewGuid(), Name = "Акушер-гинеколог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Анестезиолог-реаниматолог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Дерматовенеролог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Инфекционист", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Кардиолог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Невролог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Онколог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Ортопед", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Педиатр", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Ревматолог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Стоматолог", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Хирург", CreateTime = DateTime.UtcNow },
                new Speciality { Id = Guid.NewGuid(), Name = "Эндокринолог", CreateTime = DateTime.UtcNow }
            );
        }
    }
}
