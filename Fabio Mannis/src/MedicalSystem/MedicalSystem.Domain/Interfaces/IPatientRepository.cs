using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Domain.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetByTaxCodeAsync(string taxCode);
    }
}