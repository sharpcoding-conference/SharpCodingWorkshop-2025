using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Application.Interfaces;

namespace MedicalSystem.API.Controllers
{
    [Route("api/medical-facilities")]
    [ApiController]
    public class MedicalFacilityController : ControllerBase
    {
        private readonly IMedicalFacilityService _medicalFacilityService;

        public MedicalFacilityController(IMedicalFacilityService medicalFacilityService)
        {
            _medicalFacilityService = medicalFacilityService;
        }

        /// <summary>
        /// Retrieves a medical facility by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalFacilityById(Guid id)
        {
            var facility = await _medicalFacilityService.GetMedicalFacilityByIdAsync(id);
            if (facility == null) return NotFound();
            return Ok(facility);
        }

        /// <summary>
        /// Retrieves all medical facilities.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllMedicalFacilities()
        {
            var facilities = await _medicalFacilityService.GetAllMedicalFacilitiesAsync();
            return Ok(facilities);
        }

        /// <summary>
        /// Retrieves a medical facility by name.
        /// </summary>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetMedicalFacilityByName(string name)
        {
            var facility = await _medicalFacilityService.GetMedicalFacilityByNameAsync(name);
            if (facility == null) return NotFound();
            return Ok(facility);
        }

        /// <summary>
        /// Retrieves doctors working at a specific medical facility.
        /// </summary>
        [HttpGet("{facilityId}/doctors")]
        public async Task<IActionResult> GetDoctorsByFacilityId(Guid facilityId)
        {
            var doctors = await _medicalFacilityService.GetDoctorsByFacilityIdAsync(facilityId);
            return Ok(doctors);
        }

        /// <summary>
        /// Checks if a medical facility exists by name.
        /// </summary>
        [HttpGet("exists/{name}")]
        public async Task<IActionResult> ExistsByName(string name)
        {
            var exists = await _medicalFacilityService.ExistsByNameAsync(name);
            return Ok(new { exists });
        }

        /// <summary>
        /// Adds a new medical facility.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddMedicalFacility([FromBody] MedicalFacilityDto medicalFacilityDto)
        {
            if (medicalFacilityDto == null) return BadRequest("Invalid facility data.");
            await _medicalFacilityService.AddMedicalFacilityAsync(medicalFacilityDto);
            return CreatedAtAction(nameof(GetMedicalFacilityById), new { id = medicalFacilityDto.Id }, medicalFacilityDto);
        }

        /// <summary>
        /// Updates an existing medical facility.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalFacility(Guid id, [FromBody] MedicalFacilityDto medicalFacilityDto)
        {
            if (medicalFacilityDto == null || id != medicalFacilityDto.Id) return BadRequest("Invalid facility data.");
            await _medicalFacilityService.UpdateMedicalFacilityAsync(medicalFacilityDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a medical facility by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalFacility(Guid id)
        {
            await _medicalFacilityService.DeleteMedicalFacilityAsync(id);
            return NoContent();
        }
    }
}
