using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalSystem.Application.DTOs;

namespace MedicalSystem.Application.Interfaces
{
    public interface IDiagnosisService
    {
        Task<DiagnosisDto> GetDiagnosisByIdAsync(Guid id);
        Task<IEnumerable<DiagnosisDto>> GetAllDiagnosesAsync();
        Task<DiagnosisDto> GetDiagnosisByAppointmentIdAsync(Guid appointmentId);
        Task<IEnumerable<DiagnosisDto>> GetDiagnosesByPatientIdAsync(Guid patientId);
        Task<IEnumerable<DiagnosisDto>> GetDiagnosesByDoctorIdAsync(Guid doctorId);
        Task AddDiagnosisAsync(DiagnosisDto diagnosisDto);
        Task UpdateDiagnosisAsync(DiagnosisDto diagnosisDto);
        Task DeleteDiagnosisAsync(Guid id);
    }
}