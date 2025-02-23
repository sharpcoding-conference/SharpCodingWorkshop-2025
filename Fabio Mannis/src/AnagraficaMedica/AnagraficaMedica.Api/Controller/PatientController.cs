using AnagraficaMedica.Application.Interfaces;
using AnagraficaMedica.Application.Services;
using AnagraficaMedica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace AnagraficaMedica.Presentation.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientController(IPatientService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllPatientsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var patient = await _service.GetPatientByIdAsync(id);
            return patient == null ? NotFound() : Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            await _service.AddPatientAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Patient patient)
        {
            if (id != patient.Id) return BadRequest();
            await _service.UpdatePatientAsync(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeletePatientAsync(id);
            return NoContent();
        }
    }
}