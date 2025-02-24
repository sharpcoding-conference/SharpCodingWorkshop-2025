using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Application.Interfaces;

namespace MedicalSystem.API.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// Retrieves a doctor by their ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        /// <summary>
        /// Retrieves all doctors.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        /// <summary>
        /// Retrieves doctors by specialization.
        /// </summary>
        [HttpGet("specialization/{specialization}")]
        public async Task<IActionResult> GetDoctorsBySpecialization(string specialization)
        {
            var doctors = await _doctorService.GetDoctorsBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        /// <summary>
        /// Adds a new doctor.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDto doctorDto)
        {
            if (doctorDto == null) return BadRequest("Invalid doctor data.");
            await _doctorService.AddDoctorAsync(doctorDto);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctorDto.Id }, doctorDto);
        }

        /// <summary>
        /// Updates an existing doctor.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] DoctorDto doctorDto)
        {
            if (doctorDto == null || id != doctorDto.Id) return BadRequest("Invalid doctor data.");
            await _doctorService.UpdateDoctorAsync(doctorDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a doctor by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}
