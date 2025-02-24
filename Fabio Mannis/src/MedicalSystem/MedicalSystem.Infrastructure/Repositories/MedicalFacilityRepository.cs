using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Interfaces;
using MedicalSystem.Infrastructure.Persistence;

namespace MedicalSystem.Infrastructure.Repositories
{
    public class MedicalFacilityRepository : BaseRepository<MedicalFacility>, IMedicalFacilityRepository
    {
        public MedicalFacilityRepository(ApplicationDbContext context) : base(context) { }

        /// <summary>
        /// Retrieves a medical facility by its name.
        /// </summary>
        /// <param name="name">The name of the medical facility.</param>
        /// <returns>The medical facility that matches the given name.</returns>
        public async Task<MedicalFacility> GetByNameAsync(string name)
        {
            return await _context.MedicalFacilities
                .FirstOrDefaultAsync(mf => mf.Name == name);
        }

        /// <summary>
        /// Retrieves all doctors working in a specific medical facility.
        /// </summary>
        /// <param name="facilityId">The ID of the medical facility.</param>
        /// <returns>A list of doctors associated with the given facility.</returns>
        public async Task<IEnumerable<Doctor>> GetDoctorsByFacilityIdAsync(Guid facilityId)
        {
            return await _context.Doctors
                .Where(d => d.MedicalFacilityId == facilityId)
                .ToListAsync();
        }

        /// <summary>
        /// Checks if a medical facility exists based on its name.
        /// </summary>
        /// <param name="name">The name of the medical facility.</param>
        /// <returns>True if the facility exists, otherwise false.</returns>
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.MedicalFacilities
                .AnyAsync(mf => mf.Name == name);
        }
    }
}