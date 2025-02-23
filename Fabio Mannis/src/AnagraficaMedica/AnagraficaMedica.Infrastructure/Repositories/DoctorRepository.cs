using Microsoft.EntityFrameworkCore;
using AnagraficaMedica.Domain.Entities;
using AnagraficaMedica.Domain.Interfaces;
using AnagraficaMedica.Infrastructure.Persistence;

namespace AnagraficaMedica.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => await _context.Doctors.ToListAsync();

        public async Task<Doctor> GetByIdAsync(Guid id) => await _context.Doctors.FindAsync(id);

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}