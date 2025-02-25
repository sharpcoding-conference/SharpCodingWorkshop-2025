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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) throw new Exception("Patient not found.");
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        public async Task<PatientDto> GetPatientByTaxCodeAsync(string taxCode)
        {
            var patient = await _patientRepository.GetByTaxCodeAsync(taxCode);
            if (patient == null) throw new Exception("Patient not found.");
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task AddPatientAsync(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _patientRepository.AddAsync(patient);
        }

        public async Task UpdatePatientAsync(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeletePatientAsync(Guid id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}
