using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Application.Interfaces;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Interfaces;

namespace MedicalSystem.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null) throw new Exception("Doctor not found.");
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization)
        {
            var doctors = await _doctorRepository.GetBySpecializationAsync(specialization);
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task AddDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.AddAsync(doctor);
        }

        public async Task UpdateDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task DeleteDoctorAsync(Guid id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }
}
