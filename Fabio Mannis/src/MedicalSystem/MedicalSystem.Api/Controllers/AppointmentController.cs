using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Application.Interfaces;
using MedicalSystem.Domain.Enums;

namespace MedicalSystem.API.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Retrieves an appointment by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        /// <summary>
        /// Retrieves all appointments.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        /// <summary>
        /// Retrieves appointments for a specific patient.
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatientId(Guid patientId)
        {
            var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);
            return Ok(appointments);
        }

        /// <summary>
        /// Retrieves appointments for a specific doctor.
        /// </summary>
        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctorId(Guid doctorId)
        {
            var appointments = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);
            return Ok(appointments);
        }

        /// <summary>
        /// Retrieves appointments for a doctor within a specific date range.
        /// </summary>
        [HttpGet("doctor/{doctorId}/date-range")]
        public async Task<IActionResult> GetAppointmentsByDoctorIdAndDateRange(Guid doctorId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var appointments = await _appointmentService.GetAppointmentsByDoctorIdAndDateRangeAsync(doctorId, startDate, endDate);
            return Ok(appointments);
        }

        /// <summary>
        /// Retrieves appointments by status.
        /// </summary>
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAppointmentsByStatus(AppointmentStatus status)
        {
            var appointments = await _appointmentService.GetAppointmentsByStatusAsync(status);
            return Ok(appointments);
        }

        /// <summary>
        /// Checks if a doctor is available at a specific date and time.
        /// </summary>
        [HttpGet("doctor/{doctorId}/availability")]
        public async Task<IActionResult> IsDoctorAvailable(Guid doctorId, [FromQuery] DateTime dateTime)
        {
            var isAvailable = await _appointmentService.IsDoctorAvailableAsync(doctorId, dateTime);
            return Ok(new { available = isAvailable });
        }

        /// <summary>
        /// Adds a new appointment.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null) return BadRequest("Invalid appointment data.");
            await _appointmentService.AddAppointmentAsync(appointmentDto);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointmentDto.Id }, appointmentDto);
        }

        /// <summary>
        /// Updates an existing appointment.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null || id != appointmentDto.Id) return BadRequest("Invalid appointment data.");
            await _appointmentService.UpdateAppointmentAsync(appointmentDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes an appointment by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }
    }
}
