using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Domain.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        /// <summary>
        /// Retrieves all reports associated with a specific diagnosis.
        /// </summary>
        /// <param name="diagnosisId">The ID of the diagnosis.</param>
        /// <returns>A list of reports associated with the given diagnosis.</returns>
        Task<IEnumerable<Report>> GetByDiagnosisIdAsync(Guid diagnosisId);

        /// <summary>
        /// Retrieves reports within a specific date range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of reports created within the given date range.</returns>
        Task<IEnumerable<Report>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}