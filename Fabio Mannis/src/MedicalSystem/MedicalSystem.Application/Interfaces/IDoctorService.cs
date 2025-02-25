using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalSystem.Application.DTOs;

namespace MedicalSystem.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetDoctorByIdAsync(Guid id);
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization);
        Task AddDoctorAsync(DoctorDto doctorDto);
        Task UpdateDoctorAsync(DoctorDto doctorDto);
        Task DeleteDoctorAsync(Guid id);
    }
}