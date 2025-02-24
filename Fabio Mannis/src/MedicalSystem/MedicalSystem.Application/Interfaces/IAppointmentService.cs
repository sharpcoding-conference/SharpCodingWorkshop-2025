using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Domain.Enums;

namespace MedicalSystem.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientIdAsync(Guid patientId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAndDateRangeAsync(Guid doctorId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(AppointmentStatus status);
        Task<bool> IsDoctorAvailableAsync(Guid doctorId, DateTime dateTime);
        Task AddAppointmentAsync(AppointmentDto appointmentDto);
        Task UpdateAppointmentAsync(AppointmentDto appointmentDto);
        Task DeleteAppointmentAsync(Guid id);
    }
}