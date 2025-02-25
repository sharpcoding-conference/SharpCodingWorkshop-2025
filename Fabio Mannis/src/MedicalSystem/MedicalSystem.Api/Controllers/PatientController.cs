using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Application.Interfaces;

namespace MedicalSystem.API.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Retrieves a patient by their ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        /// <summary>
        /// Retrieves all patients.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        /// <summary>
        /// Retrieves a patient by their tax code.
        /// </summary>
        [HttpGet("taxcode/{taxCode}")]
        public async Task<IActionResult> GetPatientByTaxCode(string taxCode)
        {
            var patient = await _patientService.GetPatientByTaxCodeAsync(taxCode);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        /// <summary>
        /// Adds a new patient.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto patientDto)
        {
            if (patientDto == null) return BadRequest("Invalid patient data.");
            await _patientService.AddPatientAsync(patientDto);
            return CreatedAtAction(nameof(GetPatientById), new { id = patientDto.Id }, patientDto);
        }

        /// <summary>
        /// Updates an existing patient.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientDto patientDto)
        {
            if (patientDto == null || id != patientDto.Id) return BadRequest("Invalid patient data.");
            await _patientService.UpdatePatientAsync(patientDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a patient by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
