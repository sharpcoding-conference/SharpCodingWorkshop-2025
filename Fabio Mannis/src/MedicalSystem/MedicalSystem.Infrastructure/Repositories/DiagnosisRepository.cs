using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Interfaces;
using MedicalSystem.Infrastructure.Persistence;

namespace MedicalSystem.Infrastructure.Repositories
{
    public class DiagnosisRepository : BaseRepository<Diagnosis>, IDiagnosisRepository
    {
        public DiagnosisRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Diagnosis> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await _context.Diagnoses.FirstOrDefaultAsync(d => d.AppointmentId == appointmentId);
        }

        public async Task<IEnumerable<Diagnosis>> GetDiagnosesByPatientIdAsync(Guid patientId)
        {
            return await _context.Diagnoses
                .Include(d => d.Appointment)
                .Where(d => d.Appointment.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnosis>> GetDiagnosesByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Diagnoses
                .Include(d => d.Appointment)
                .Where(d => d.Appointment.DoctorId == doctorId)
                .ToListAsync();
        }
    }
}