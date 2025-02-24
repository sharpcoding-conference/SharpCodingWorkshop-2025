using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Enums;
using MedicalSystem.Domain.Interfaces;
using MedicalSystem.Infrastructure.Persistence;

namespace MedicalSystem.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) { }

        /// <summary>
        /// Retrieves all appointments for a specific patient.
        /// </summary>
        /// <param name="patientId">The ID of the patient.</param>
        /// <returns>A list of appointments for the given patient.</returns>
        public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves all appointments for a specific doctor.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <returns>A list of appointments for the given doctor.</returns>
        public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves appointments for a doctor within a specific date range.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of appointments for the given doctor within the date range.</returns>
        public async Task<IEnumerable<Appointment>> GetByDoctorIdAndDateRangeAsync(Guid doctorId, DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == doctorId && a.DateTime >= startDate && a.DateTime <= endDate)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves all appointments with a specific status.
        /// </summary>
        /// <param name="status">The status of the appointment (e.g., Booked, Completed, Canceled).</param>
        /// <returns>A list of appointments with the specified status.</returns>
        public async Task<IEnumerable<Appointment>> GetByStatusAsync(AppointmentStatus status)
        {
            return await _context.Appointments
                .Where(a => a.Status == status)
                .ToListAsync();
        }

        /// <summary>
        /// Checks if a doctor has an appointment at a specific date and time.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <param name="dateTime">The date and time of the appointment.</param>
        /// <returns>True if the doctor has an appointment at the given time, otherwise false.</returns>
        public async Task<bool> IsDoctorAvailableAsync(Guid doctorId, DateTime dateTime)
        {
            return !await _context.Appointments
                .AnyAsync(a => a.DoctorId == doctorId && a.DateTime == dateTime);
        }
    }
}
