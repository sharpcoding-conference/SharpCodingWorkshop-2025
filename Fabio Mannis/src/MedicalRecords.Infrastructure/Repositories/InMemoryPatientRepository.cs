using MedicalRecords.Domain.Entities;
using MedicalRecords.Domain.Interfaces;

namespace MedicalRecords.Infrastructure.Repositories
{
    public class InMemoryPatientRepository : IPatientRepository
    {
        private readonly List<Patient> _patients = new();

        public IEnumerable<Patient> GetAll() => _patients;

        public Patient? GetById(Guid id) => _patients.FirstOrDefault(p => p.Id == id);

        public void Add(Patient patient) => _patients.Add(patient);

        public void Update(Patient patient)
        {
            var existingPatient = GetById(patient.Id);
            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.DateOfBirth = patient.DateOfBirth;
                existingPatient.Gender = patient.Gender;
                existingPatient.TaxCode = patient.TaxCode;
            }
        }

        public void Delete(Guid id) => _patients.RemoveAll(p => p.Id == id);
    }
}