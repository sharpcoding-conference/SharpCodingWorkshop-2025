using AnagraficaMedica.Domain.Entities;
using AnagraficaMedica.Domain.Interfaces;
using AnagraficaMedica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnagraficaMedica.Infrastructure.Repositories
{
    public class HealthcareFacilityRepository : IHealthcareFacilityRepository
    {
        private readonly ApplicationDbContext _context;

        public HealthcareFacilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HealthcareFacility>> GetAllAsync()
        {
            return await _context.HealthcareFacilities
                .Include(h => h.Doctors)
                .ToListAsync();
        }

        public async Task<HealthcareFacility?> GetByIdAsync(Guid id)
        {
            return await _context.HealthcareFacilities
                .Include(h => h.Doctors)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task AddAsync(HealthcareFacility facility)
        {
            _context.HealthcareFacilities.Add(facility);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HealthcareFacility facility)
        {
            _context.HealthcareFacilities.Update(facility);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var facility = await _context.HealthcareFacilities.FindAsync(id);
            if (facility != null)
            {
                _context.HealthcareFacilities.Remove(facility);
                await _context.SaveChangesAsync();
            }
        }
    }
}