using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Interfaces;
using MedicalSystem.Infrastructure.Persistence;

namespace MedicalSystem.Infrastructure.Repositories
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext context) : base(context) { }

        /// <summary>
        /// Retrieves all reports associated with a specific diagnosis.
        /// </summary>
        /// <param name="diagnosisId">The ID of the diagnosis.</param>
        /// <returns>A list of reports associated with the given diagnosis.</returns>
        public async Task<IEnumerable<Report>> GetByDiagnosisIdAsync(Guid diagnosisId)
        {
            return await _context.Reports
                .Where(r => r.DiagnosisId == diagnosisId)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves reports within a specific date range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of reports created within the given date range.</returns>
        public async Task<IEnumerable<Report>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Reports
                .Where(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate)
                .ToListAsync();
        }
    }
}