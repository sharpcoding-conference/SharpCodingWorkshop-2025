using AnagraficaMedica.Application.Interfaces;
using AnagraficaMedica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace AnagraficaMedica.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcareFacilityController : ControllerBase
    {
        private readonly IHealthcareFacilityService _healthcareFacilityService;

        public HealthcareFacilityController(IHealthcareFacilityService healthcareFacilityService)
        {
            _healthcareFacilityService = healthcareFacilityService;
        }

        // GET: api/HealthcareFacility
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthcareFacility>>> GetHealthcareFacilities()
        {
            var facilities = await _healthcareFacilityService.GetAllHealthcareFacilitiesAsync();
            return Ok(facilities);
        }

        // GET: api/HealthcareFacility/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthcareFacility>> GetHealthcareFacilityById(Guid id)
        {
            var facility = await _healthcareFacilityService.GetHealthcareFacilityByIdAsync(id);
            if (facility == null)
            {
                return NotFound();
            }
            return Ok(facility);
        }

        // POST: api/HealthcareFacility
        [HttpPost]
        public async Task<ActionResult<HealthcareFacility>> CreateHealthcareFacility(HealthcareFacility healthcareFacility)
        {
            if (healthcareFacility == null)
            {
                return BadRequest("La struttura sanitaria è null.");
            }

            await _healthcareFacilityService.AddHealthcareFacilityAsync(healthcareFacility);
            return CreatedAtAction(nameof(GetHealthcareFacilityById), new { id = healthcareFacility.Id }, healthcareFacility);
        }

        // PUT: api/HealthcareFacility/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHealthcareFacility(Guid id, HealthcareFacility healthcareFacility)
        {
            if (id != healthcareFacility.Id)
            {
                return BadRequest("ID della struttura sanitaria non corrispondente.");
            }

            var existingFacility = await _healthcareFacilityService.GetHealthcareFacilityByIdAsync(id);
            if (existingFacility == null)
            {
                return NotFound();
            }

            await _healthcareFacilityService.UpdateHealthcareFacilityAsync(healthcareFacility);
            return NoContent(); // Operazione riuscita senza contenuto da restituire
        }

        // DELETE: api/HealthcareFacility/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthcareFacility(Guid id)
        {
            var existingFacility = await _healthcareFacilityService.GetHealthcareFacilityByIdAsync(id);
            if (existingFacility == null)
            {
                return NotFound();
            }

            await _healthcareFacilityService.DeleteHealthcareFacilityAsync(id);
            return NoContent(); // Operazione riuscita senza contenuto da restituire
        }
    }
}
