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
    public class MedicalFacilityService : IMedicalFacilityService
    {
        private readonly IMedicalFacilityRepository _medicalFacilityRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public MedicalFacilityService(IMedicalFacilityRepository medicalFacilityRepository, IDoctorRepository doctorRepository, IMapper mapper)
        {
            _medicalFacilityRepository = medicalFacilityRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<MedicalFacilityDto> GetMedicalFacilityByIdAsync(Guid id)
        {
            var facility = await _medicalFacilityRepository.GetByIdAsync(id);
            if (facility == null) throw new Exception("Medical facility not found.");
            return _mapper.Map<MedicalFacilityDto>(facility);
        }

        public async Task<IEnumerable<MedicalFacilityDto>> GetAllMedicalFacilitiesAsync()
        {
            var facilities = await _medicalFacilityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicalFacilityDto>>(facilities);
        }

        public async Task<MedicalFacilityDto> GetMedicalFacilityByNameAsync(string name)
        {
            var facility = await _medicalFacilityRepository.GetByNameAsync(name);
            if (facility == null) throw new Exception("Medical facility not found.");
            return _mapper.Map<MedicalFacilityDto>(facility);
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsByFacilityIdAsync(Guid facilityId)
        {
            var doctors = await _medicalFacilityRepository.GetDoctorsByFacilityIdAsync(facilityId);
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _medicalFacilityRepository.ExistsByNameAsync(name);
        }

        public async Task AddMedicalFacilityAsync(MedicalFacilityDto medicalFacilityDto)
        {
            var facility = _mapper.Map<MedicalFacility>(medicalFacilityDto);
            await _medicalFacilityRepository.AddAsync(facility);
        }

        public async Task UpdateMedicalFacilityAsync(MedicalFacilityDto medicalFacilityDto)
        {
            var facility = _mapper.Map<MedicalFacility>(medicalFacilityDto);
            await _medicalFacilityRepository.UpdateAsync(facility);
        }

        public async Task DeleteMedicalFacilityAsync(Guid id)
        {
            await _medicalFacilityRepository.DeleteAsync(id);
        }
    }
}
