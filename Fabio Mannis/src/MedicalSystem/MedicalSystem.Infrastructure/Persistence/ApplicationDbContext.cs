using MedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using MedicalSystem.Domain.Enums;

namespace MedicalSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<MedicalFacility> MedicalFacilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Metodo per popolare il database solo se è in-memory.
        /// </summary>
        public static void SeedData(ApplicationDbContext context)
        {
            if (context.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
            {
                // Verifica se già esistono dati, se no popola il database
                if (!context.MedicalFacilities.Any())
                {
                    var facility1 = new MedicalFacility { Id = Guid.NewGuid(), Name = "General Hospital", Address = "123 Main St", Phone = "123-456-7890" };
                    var facility2 = new MedicalFacility { Id = Guid.NewGuid(), Name = "Specialty Clinic", Address = "456 Health Rd", Phone = "987-654-3210" };
                    context.MedicalFacilities.AddRange(facility1, facility2);

                    var doctor1 = new Doctor { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Specialization = "Cardiology", Email = "john.doe@example.com", Phone = "111-222-3333", MedicalFacilityId = facility1.Id };
                    var doctor2 = new Doctor { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", Specialization = "Neurology", Email = "alice.smith@example.com", Phone = "444-555-6666", MedicalFacilityId = facility2.Id };
                    context.Doctors.AddRange(doctor1, doctor2);

                    var patient1 = new Patient { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Johnson", TaxCode = "MJ123456", Email = "michael.j@example.com", Phone = "777-888-9999" };
                    var patient2 = new Patient { Id = Guid.NewGuid(), FirstName = "Emma", LastName = "Brown", TaxCode = "EB654321", Email = "emma.b@example.com", Phone = "123-456-7890" };
                    context.Patients.AddRange(patient1, patient2);

                    var appointment1 = new Appointment { Id = Guid.NewGuid(), PatientId = patient1.Id, DoctorId = doctor1.Id, DateTime = DateTime.UtcNow.AddDays(2), Status = AppointmentStatus.Booked };
                    var appointment2 = new Appointment { Id = Guid.NewGuid(), PatientId = patient2.Id, DoctorId = doctor2.Id, DateTime = DateTime.UtcNow.AddDays(5), Status = AppointmentStatus.Canceled };
                    context.Appointments.AddRange(appointment1, appointment2);

                    var diagnosis1 = new Diagnosis { Id = Guid.NewGuid(), AppointmentId = appointment1.Id, Description = "Mild flu symptoms" };
                    var diagnosis2 = new Diagnosis { Id = Guid.NewGuid(), AppointmentId = appointment2.Id, Description = "High blood pressure detected" };
                    context.Diagnoses.AddRange(diagnosis1, diagnosis2);

                    var report1 = new Report { Id = Guid.NewGuid(), DiagnosisId = diagnosis1.Id, FilePath = "/reports/report1.pdf" };
                    var report2 = new Report { Id = Guid.NewGuid(), DiagnosisId = diagnosis2.Id, FilePath = "/reports/report2.pdf" };
                    context.Reports.AddRange(report1, report2);

                    context.SaveChanges();
                }
            }
        }
    }
}
