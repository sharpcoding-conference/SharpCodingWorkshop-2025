using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Domain.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization);
    }
}