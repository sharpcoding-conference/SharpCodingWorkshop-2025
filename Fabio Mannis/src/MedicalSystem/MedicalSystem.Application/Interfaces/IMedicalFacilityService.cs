using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalSystem.Application.DTOs;

namespace MedicalSystem.Application.Interfaces
{
    public interface IMedicalFacilityService
    {
        Task<MedicalFacilityDto> GetMedicalFacilityByIdAsync(Guid id);
        Task<IEnumerable<MedicalFacilityDto>> GetAllMedicalFacilitiesAsync();
        Task<MedicalFacilityDto> GetMedicalFacilityByNameAsync(string name);
        Task<IEnumerable<DoctorDto>> GetDoctorsByFacilityIdAsync(Guid facilityId);
        Task<bool> ExistsByNameAsync(string name);
        Task AddMedicalFacilityAsync(MedicalFacilityDto medicalFacilityDto);
        Task UpdateMedicalFacilityAsync(MedicalFacilityDto medicalFacilityDto);
        Task DeleteMedicalFacilityAsync(Guid id);
    }
}