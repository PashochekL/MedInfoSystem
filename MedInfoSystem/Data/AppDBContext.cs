using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MedInfoSystem.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        DbSet <Inspection> Inspections { get; set; }

        DbSet<Consultation> Consultations { get; set; }

        DbSet<Patient> Patients { get; set; }

        DbSet<Diagnosis> Diagnoses { get; set; }

        DbSet<Doctor> Doctors { get; set; }

        DbSet<Speciality> Specialities { get; set; }

        DbSet<Comment> Comments { get; set; }

    }
}
