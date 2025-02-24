using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Application.Interfaces;

namespace MedicalSystem.API.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Retrieves a report by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(Guid id)
        {
            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        /// <summary>
        /// Retrieves all reports.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        /// <summary>
        /// Retrieves reports associated with a specific diagnosis.
        /// </summary>
        [HttpGet("diagnosis/{diagnosisId}")]
        public async Task<IActionResult> GetReportsByDiagnosisId(Guid diagnosisId)
        {
            var reports = await _reportService.GetReportsByDiagnosisIdAsync(diagnosisId);
            return Ok(reports);
        }

        /// <summary>
        /// Retrieves reports within a specific date range.
        /// </summary>
        [HttpGet("date-range")]
        public async Task<IActionResult> GetReportsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var reports = await _reportService.GetReportsByDateRangeAsync(startDate, endDate);
            return Ok(reports);
        }

        /// <summary>
        /// Adds a new report.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddReport([FromBody] ReportDto reportDto)
        {
            if (reportDto == null) return BadRequest("Invalid report data.");
            await _reportService.AddReportAsync(reportDto);
            return CreatedAtAction(nameof(GetReportById), new { id = reportDto.Id }, reportDto);
        }

        /// <summary>
        /// Updates an existing report.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(Guid id, [FromBody] ReportDto reportDto)
        {
            if (reportDto == null || id != reportDto.Id) return BadRequest("Invalid report data.");
            await _reportService.UpdateReportAsync(reportDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a report by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            await _reportService.DeleteReportAsync(id);
            return NoContent();
        }
    }
}
