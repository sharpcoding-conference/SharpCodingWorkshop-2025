using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnagraficaMedica.Domain.Entities;

namespace AnagraficaMedica.Application.Interfaces
{
    public interface IHealthcareFacilityService
    {
        Task<IEnumerable<HealthcareFacility>> GetAllHealthcareFacilitiesAsync();
        Task<HealthcareFacility> GetHealthcareFacilityByIdAsync(Guid id);
        Task AddHealthcareFacilityAsync(HealthcareFacility healthcareFacility);
        Task UpdateHealthcareFacilityAsync(HealthcareFacility healthcareFacility);
        Task DeleteHealthcareFacilityAsync(Guid id);
    }
}