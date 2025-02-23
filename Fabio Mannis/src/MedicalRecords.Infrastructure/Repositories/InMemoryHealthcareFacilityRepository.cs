using MedicalRecords.Domain.Entities;
using MedicalRecords.Domain.Interfaces;

namespace MedicalRecords.Infrastructure.Repositories
{
    public class InMemoryHealthcareFacilityRepository : IHealthcareFacilityRepository
    {
        private readonly List<HealthcareFacility> _facilities = new();

        public IEnumerable<HealthcareFacility> GetAll() => _facilities;

        public HealthcareFacility? GetById(Guid id) => _facilities.FirstOrDefault(f => f.Id == id);

        public void Add(HealthcareFacility facility) => _facilities.Add(facility);

        public void Update(HealthcareFacility facility)
        {
            var existingFacility = GetById(facility.Id);
            if (existingFacility != null)
            {
                existingFacility.Name = facility.Name;
                existingFacility.Address = facility.Address;
                existingFacility.Type = facility.Type;
                existingFacility.DoctorIds = facility.DoctorIds;
            }
        }

        public void Delete(Guid id) => _facilities.RemoveAll(f => f.Id == id);
    }
}