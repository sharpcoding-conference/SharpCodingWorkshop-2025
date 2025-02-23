using MedicalRecords.Domain.Entities;
using MedicalRecords.Domain.Interfaces;

namespace MedicalRecords.Infrastructure.Repositories
{
    public class InMemoryTherapyRepository : ITherapyRepository
    {
        private readonly List<Therapy> _therapies = new();

        public IEnumerable<Therapy> GetAll() => _therapies;

        public IEnumerable<Therapy> GetByPatientId(Guid patientId) =>
            _therapies.Where(t => t.PatientId == patientId);

        public Therapy? GetById(Guid id) => _therapies.FirstOrDefault(t => t.Id == id);

        public void Add(Therapy therapy) => _therapies.Add(therapy);

        public void Update(Therapy therapy)
        {
            var existingTherapy = GetById(therapy.Id);
            if (existingTherapy != null)
            {
                existingTherapy.Medications = therapy.Medications;
                existingTherapy.TreatmentPlan = therapy.TreatmentPlan;
                existingTherapy.EndDate = therapy.EndDate;
            }
        }

        public void Delete(Guid id) => _therapies.RemoveAll(t => t.Id == id);
    }
}