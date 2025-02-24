using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnagraficaMedica.Application.Interfaces;
using AnagraficaMedica.Domain.Entities;
using AnagraficaMedica.Domain.Interfaces;

namespace AnagraficaMedica.Application.Services
{
    public class HealthcareFacilityService : IHealthcareFacilityService
    {
        private readonly IHealthcareFacilityRepository _healthcareFacilityRepository;

        public HealthcareFacilityService(IHealthcareFacilityRepository healthcareFacilityRepository)
        {
            _healthcareFacilityRepository = healthcareFacilityRepository;
        }

        // Get all healthcare facilities
        public async Task<IEnumerable<HealthcareFacility>> GetAllHealthcareFacilitiesAsync()
        {
            return await _healthcareFacilityRepository.GetAllAsync();
        }

        // Get a healthcare facility by its ID
        public async Task<HealthcareFacility> GetHealthcareFacilityByIdAsync(Guid id)
        {
            return await _healthcareFacilityRepository.GetByIdAsync(id);
        }

        // Add a new healthcare facility
        public async Task AddHealthcareFacilityAsync(HealthcareFacility healthcareFacility)
        {
            if (healthcareFacility == null)
                throw new ArgumentNullException(nameof(healthcareFacility));
            await _healthcareFacilityRepository.AddAsync(healthcareFacility);
        }

        // Update an existing healthcare facility
        public async Task UpdateHealthcareFacilityAsync(HealthcareFacility healthcareFacility)
        {
            if (healthcareFacility == null)
                throw new ArgumentNullException(nameof(healthcareFacility));
            await _healthcareFacilityRepository.UpdateAsync(healthcareFacility);
        }

        // Delete a healthcare facility
        public async Task DeleteHealthcareFacilityAsync(Guid id)
        {
            await _healthcareFacilityRepository.DeleteAsync(id);
        }
    }
}