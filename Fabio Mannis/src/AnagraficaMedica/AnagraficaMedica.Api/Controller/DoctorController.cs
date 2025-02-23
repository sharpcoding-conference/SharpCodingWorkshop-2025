using AnagraficaMedica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AnagraficaMedica.Application.Services;
using AnagraficaMedica.Domain.Entities;

namespace AnagraficaMedica.Presentation.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _service.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var doctor = await _service.GetDoctorByIdAsync(id);
            return doctor == null ? NotFound() : Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Doctor doctor)
        {
            await _service.AddDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id) return BadRequest();
            await _service.UpdateDoctorAsync(doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}