using AnagraficaMedica.Domain.Entities;
using AnagraficaMedica.Domain.Interfaces;
using AnagraficaMedica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AnagraficaMedica.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() => await _context.Patients.ToListAsync();

        public async Task<Patient> GetByIdAsync(Guid id) => await _context.Patients.FindAsync(id);

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}