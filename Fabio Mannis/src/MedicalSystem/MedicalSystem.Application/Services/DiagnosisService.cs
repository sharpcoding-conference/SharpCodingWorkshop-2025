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
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IDiagnosisRepository _diagnosisRepository;
        private readonly IMapper _mapper;

        public DiagnosisService(IDiagnosisRepository diagnosisRepository, IMapper mapper)
        {
            _diagnosisRepository = diagnosisRepository;
            _mapper = mapper;
        }

        public async Task<DiagnosisDto> GetDiagnosisByIdAsync(Guid id)
        {
            var diagnosis = await _diagnosisRepository.GetByIdAsync(id);
            if (diagnosis == null) throw new Exception("Diagnosis not found.");
            return _mapper.Map<DiagnosisDto>(diagnosis);
        }

        public async Task<IEnumerable<DiagnosisDto>> GetAllDiagnosesAsync()
        {
            var diagnoses = await _diagnosisRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DiagnosisDto>>(diagnoses);
        }

        public async Task<DiagnosisDto> GetDiagnosisByAppointmentIdAsync(Guid appointmentId)
        {
            var diagnosis = await _diagnosisRepository.GetByAppointmentIdAsync(appointmentId);
            if (diagnosis == null) throw new Exception("Diagnosis not found.");
            return _mapper.Map<DiagnosisDto>(diagnosis);
        }

        public async Task<IEnumerable<DiagnosisDto>> GetDiagnosesByPatientIdAsync(Guid patientId)
        {
            var diagnoses = await _diagnosisRepository.GetDiagnosesByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<DiagnosisDto>>(diagnoses);
        }

        public async Task<IEnumerable<DiagnosisDto>> GetDiagnosesByDoctorIdAsync(Guid doctorId)
        {
            var diagnoses = await _diagnosisRepository.GetDiagnosesByDoctorIdAsync(doctorId);
            return _mapper.Map<IEnumerable<DiagnosisDto>>(diagnoses);
        }

        public async Task AddDiagnosisAsync(DiagnosisDto diagnosisDto)
        {
            var diagnosis = _mapper.Map<Diagnosis>(diagnosisDto);
            await _diagnosisRepository.AddAsync(diagnosis);
        }

        public async Task UpdateDiagnosisAsync(DiagnosisDto diagnosisDto)
        {
            var diagnosis = _mapper.Map<Diagnosis>(diagnosisDto);
            await _diagnosisRepository.UpdateAsync(diagnosis);
        }

        public async Task DeleteDiagnosisAsync(Guid id)
        {
            await _diagnosisRepository.DeleteAsync(id);
        }
    }
}
