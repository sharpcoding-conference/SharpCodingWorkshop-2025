using AnagraficaMedica.Application.Interfaces;
using AnagraficaMedica.Domain.Entities;
using AnagraficaMedica.Domain.Interfaces;

namespace AnagraficaMedica.Application.Services
{
    public class PatientService: IPatientService
    {
        private readonly IPatientRepository _repository;
        public PatientService(IPatientRepository repository) => _repository = repository;

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync() => await _repository.GetAllAsync();
        public async Task<Patient> GetPatientByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
        public async Task AddPatientAsync(Patient patient) => await _repository.AddAsync(patient);
        public async Task UpdatePatientAsync(Patient patient) => await _repository.UpdateAsync(patient);
        public async Task DeletePatientAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}