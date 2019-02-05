using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.EntityConfiguration;
using P01_HospitalDatabase.Data.Models;
using System;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions options) 
        {
        }

        public HospitalContext()
        {
        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if(!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DiagnoseConfig());
            builder.ApplyConfiguration(new MedicamentConfig());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new PatientMedicamentConfig());
            builder.ApplyConfiguration(new VisitationConfig());
            builder.ApplyConfiguration(new DoctorConfig());
        }
    }
}
