using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Interfaces;
using MedicalSystem.Infrastructure.Persistence;

namespace MedicalSystem.Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Patient> GetByTaxCodeAsync(string taxCode)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.TaxCode == taxCode);
        }
    }
}