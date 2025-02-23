using MedicalRecords.Domain.Entities;
using MedicalRecords.Domain.Interfaces;

namespace MedicalRecords.Infrastructure.Repositories
{
    public class InMemoryClinicalRecordRepository : IClinicalRecordRepository
    {
        private readonly List<ClinicalRecord> _records = new();

        public IEnumerable<ClinicalRecord> GetAll() => _records;

        public IEnumerable<ClinicalRecord> GetByPatientId(Guid patientId) =>
            _records.Where(r => r.PatientId == patientId);

        public ClinicalRecord? GetById(Guid id) => _records.FirstOrDefault(r => r.Id == id);

        public void Add(ClinicalRecord record) => _records.Add(record);

        public void Update(ClinicalRecord record)
        {
            var existingRecord = GetById(record.Id);
            if (existingRecord != null)
            {
                existingRecord.Diagnosis = record.Diagnosis;
                existingRecord.Treatment = record.Treatment;
                existingRecord.Notes = record.Notes;
                existingRecord.Date = record.Date;
            }
        }

        public void Delete(Guid id) => _records.RemoveAll(r => r.Id == id);
    }
}