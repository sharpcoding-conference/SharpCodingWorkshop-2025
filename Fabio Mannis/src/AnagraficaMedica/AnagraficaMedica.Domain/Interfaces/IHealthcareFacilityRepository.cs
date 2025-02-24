using AnagraficaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnagraficaMedica.Domain.Interfaces
{
    public interface IHealthcareFacilityRepository
    {
        Task<IEnumerable<HealthcareFacility>> GetAllAsync();
        Task<HealthcareFacility?> GetByIdAsync(Guid id);
        Task AddAsync(HealthcareFacility facility);
        Task UpdateAsync(HealthcareFacility facility);
        Task DeleteAsync(Guid id);
    }
}