using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Application.Interfaces;

namespace MedicalSystem.API.Controllers
{
    [Route("api/diagnoses")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosisService _diagnosisService;

        public DiagnosisController(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }

        /// <summary>
        /// Retrieves a diagnosis by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnosisById(Guid id)
        {
            var diagnosis = await _diagnosisService.GetDiagnosisByIdAsync(id);
            if (diagnosis == null) return NotFound();
            return Ok(diagnosis);
        }

        /// <summary>
        /// Retrieves all diagnoses.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllDiagnoses()
        {
            var diagnoses = await _diagnosisService.GetAllDiagnosesAsync();
            return Ok(diagnoses);
        }

        /// <summary>
        /// Retrieves a diagnosis by appointment ID.
        /// </summary>
        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetDiagnosisByAppointmentId(Guid appointmentId)
        {
            var diagnosis = await _diagnosisService.GetDiagnosisByAppointmentIdAsync(appointmentId);
            if (diagnosis == null) return NotFound();
            return Ok(diagnosis);
        }

        /// <summary>
        /// Retrieves diagnoses associated with a specific patient.
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetDiagnosesByPatientId(Guid patientId)
        {
            var diagnoses = await _diagnosisService.GetDiagnosesByPatientIdAsync(patientId);
            return Ok(diagnoses);
        }

        /// <summary>
        /// Retrieves diagnoses associated with a specific doctor.
        /// </summary>
        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetDiagnosesByDoctorId(Guid doctorId)
        {
            var diagnoses = await _diagnosisService.GetDiagnosesByDoctorIdAsync(doctorId);
            return Ok(diagnoses);
        }

        /// <summary>
        /// Adds a new diagnosis.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddDiagnosis([FromBody] DiagnosisDto diagnosisDto)
        {
            if (diagnosisDto == null) return BadRequest("Invalid diagnosis data.");
            await _diagnosisService.AddDiagnosisAsync(diagnosisDto);
            return CreatedAtAction(nameof(GetDiagnosisById), new { id = diagnosisDto.Id }, diagnosisDto);
        }

        /// <summary>
        /// Updates an existing diagnosis.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiagnosis(Guid id, [FromBody] DiagnosisDto diagnosisDto)
        {
            if (diagnosisDto == null || id != diagnosisDto.Id) return BadRequest("Invalid diagnosis data.");
            await _diagnosisService.UpdateDiagnosisAsync(diagnosisDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a diagnosis by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosis(Guid id)
        {
            await _diagnosisService.DeleteDiagnosisAsync(id);
            return NoContent();
        }
    }
}
