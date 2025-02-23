using MedicalRecords.Domain.Entities;
using MedicalRecords.Domain.Interfaces;

namespace MedicalRecords.Infrastructure.Repositories
{
    public class InMemoryDiagnosisRepository : IDiagnosisRepository
    {
        private readonly List<Diagnosis> _diagnoses = new();

        public IEnumerable<Diagnosis> GetAll() => _diagnoses;

        public IEnumerable<Diagnosis> GetByPatientId(Guid patientId) =>
            _diagnoses.Where(d => d.PatientId == patientId);

        public Diagnosis? GetById(Guid id) => _diagnoses.FirstOrDefault(d => d.Id == id);

        public void Add(Diagnosis diagnosis) => _diagnoses.Add(diagnosis);

        public void Update(Diagnosis diagnosis)
        {
            var existingDiagnosis = GetById(diagnosis.Id);
            if (existingDiagnosis != null)
            {
                existingDiagnosis.Condition = diagnosis.Condition;
                existingDiagnosis.Notes = diagnosis.Notes;
                existingDiagnosis.Date = diagnosis.Date;
            }
        }

        public void Delete(Guid id) => _diagnoses.RemoveAll(d => d.Id == id);
    }
}