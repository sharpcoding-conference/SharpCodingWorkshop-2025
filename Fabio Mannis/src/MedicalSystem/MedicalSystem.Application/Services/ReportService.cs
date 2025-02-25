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
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<ReportDto> GetReportByIdAsync(Guid id)
        {
            var report = await _reportRepository.GetByIdAsync(id);
            if (report == null) throw new Exception("Report not found.");
            return _mapper.Map<ReportDto>(report);
        }

        public async Task<IEnumerable<ReportDto>> GetAllReportsAsync()
        {
            var reports = await _reportRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<IEnumerable<ReportDto>> GetReportsByDiagnosisIdAsync(Guid diagnosisId)
        {
            var reports = await _reportRepository.GetByDiagnosisIdAsync(diagnosisId);
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<IEnumerable<ReportDto>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var reports = await _reportRepository.GetReportsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task AddReportAsync(ReportDto reportDto)
        {
            var report = _mapper.Map<Report>(reportDto);
            await _reportRepository.AddAsync(report);
        }

        public async Task UpdateReportAsync(ReportDto reportDto)
        {
            var report = _mapper.Map<Report>(reportDto);
            await _reportRepository.UpdateAsync(report);
        }

        public async Task DeleteReportAsync(Guid id)
        {
            await _reportRepository.DeleteAsync(id);
        }
    }
}
