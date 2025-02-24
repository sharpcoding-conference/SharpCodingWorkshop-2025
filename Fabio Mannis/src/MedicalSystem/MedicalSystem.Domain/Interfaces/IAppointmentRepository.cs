using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Enums;

namespace MedicalSystem.Domain.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        /// <summary>
        /// Retrieves all appointments for a specific patient.
        /// </summary>
        /// <param name="patientId">The ID of the patient.</param>
        /// <returns>A list of appointments for the given patient.</returns>
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId);

        /// <summary>
        /// Retrieves all appointments for a specific doctor.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <returns>A list of appointments for the given doctor.</returns>
        Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId);

        /// <summary>
        /// Retrieves appointments for a doctor within a specific date range.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of appointments for the given doctor within the date range.</returns>
        Task<IEnumerable<Appointment>> GetByDoctorIdAndDateRangeAsync(Guid doctorId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves all appointments with a specific status.
        /// </summary>
        /// <param name="status">The status of the appointment (e.g., Booked, Completed, Canceled).</param>
        /// <returns>A list of appointments with the specified status.</returns>
        Task<IEnumerable<Appointment>> GetByStatusAsync(AppointmentStatus status);

        /// <summary>
        /// Checks if a doctor has an appointment at a specific date and time.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <param name="dateTime">The date and time of the appointment.</param>
        /// <returns>True if the doctor has an appointment at the given time, otherwise false.</returns>
        Task<bool> IsDoctorAvailableAsync(Guid doctorId, DateTime dateTime);
    }
}
