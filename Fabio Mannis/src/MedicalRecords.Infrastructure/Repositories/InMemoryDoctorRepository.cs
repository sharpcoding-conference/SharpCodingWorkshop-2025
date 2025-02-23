using MedicalRecords.Domain.Entities;
using MedicalRecords.Domain.Interfaces;

namespace MedicalRecords.Infrastructure.Repositories
{
    public class InMemoryDoctorRepository : IDoctorRepository
    {
        private readonly List<Doctor> _doctors = new();

        public IEnumerable<Doctor> GetAll() => _doctors;

        public Doctor? GetById(Guid id) => _doctors.FirstOrDefault(d => d.Id == id);

        public void Add(Doctor doctor) => _doctors.Add(doctor);

        public void Update(Doctor doctor)
        {
            var existingDoctor = GetById(doctor.Id);
            if (existingDoctor != null)
            {
                existingDoctor.FirstName = doctor.FirstName;
                existingDoctor.LastName = doctor.LastName;
                existingDoctor.Specialty = doctor.Specialty;
            }
        }

        public void Delete(Guid id) => _doctors.RemoveAll(d => d.Id == id);
    }
}