using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalSystem.Application.DTOs;

namespace MedicalSystem.Application.Interfaces
{
    public interface IReportService
    {
        Task<ReportDto> GetReportByIdAsync(Guid id);
        Task<IEnumerable<ReportDto>> GetAllReportsAsync();
        Task<IEnumerable<ReportDto>> GetReportsByDiagnosisIdAsync(Guid diagnosisId);
        Task<IEnumerable<ReportDto>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task AddReportAsync(ReportDto reportDto);
        Task UpdateReportAsync(ReportDto reportDto);
        Task DeleteReportAsync(Guid id);
    }
}