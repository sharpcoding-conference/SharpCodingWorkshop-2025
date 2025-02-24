using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Domain.Interfaces
{
    public interface IDiagnosisRepository : IRepository<Diagnosis>
    {
        /// <summary>
        /// Retrieves a diagnosis by the associated appointment ID.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment.</param>
        /// <returns>The diagnosis associated with the given appointment ID.</returns>
        Task<Diagnosis> GetByAppointmentIdAsync(Guid appointmentId);

        /// <summary>
        /// Retrieves all diagnoses associated with a specific patient.
        /// </summary>
        /// <param name="patientId">The ID of the patient.</param>
        /// <returns>A list of diagnoses associated with the given patient.</returns>
        Task<IEnumerable<Diagnosis>> GetDiagnosesByPatientIdAsync(Guid patientId);

        /// <summary>
        /// Retrieves all diagnoses associated with a specific doctor.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <returns>A list of diagnoses associated with the given doctor.</returns>
        Task<IEnumerable<Diagnosis>> GetDiagnosesByDoctorIdAsync(Guid doctorId);
    }
}