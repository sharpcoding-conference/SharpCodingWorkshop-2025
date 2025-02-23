using AnagraficaMedica.Application.Interfaces;
using AnagraficaMedica.Domain.Interfaces;
using AnagraficaMedica.Domain.Entities;

namespace AnagraficaMedica.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository) => _repository = repository;

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync() => await _repository.GetAllAsync();

        public async Task<Doctor> GetDoctorByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task AddDoctorAsync(Doctor doctor) => await _repository.AddAsync(doctor);

        public async Task UpdateDoctorAsync(Doctor doctor) => await _repository.UpdateAsync(doctor);

        public async Task DeleteDoctorAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}