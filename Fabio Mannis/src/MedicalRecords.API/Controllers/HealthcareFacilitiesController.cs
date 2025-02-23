using MedicalRecords.Application.Services;
using MedicalRecords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecords.API.Controllers
{
    [Route("api/healthcarefacilities")]
    [ApiController]
    public class HealthcareFacilitiesController : ControllerBase
    {
        private readonly MedicalFacilityService _facilityService;

        public HealthcareFacilitiesController(MedicalFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
        public IActionResult GetAllFacilities()
        {
            var facilities = _facilityService.GetAllFacilities();
            return Ok(facilities);
        }

        [HttpGet("{id}")]
        public IActionResult GetFacilityById(Guid id)
        {
            var facility = _facilityService.GetFacilityById(id);
            if (facility == null)
                return NotFound();
            return Ok(facility);
        }

        [HttpPost]
        public IActionResult CreateFacility([FromBody] HealthcareFacility facility)
        {
            _facilityService.CreateFacility(facility);
            return CreatedAtAction(nameof(GetFacilityById), new { id = facility.Id }, facility);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFacility(Guid id, [FromBody] HealthcareFacility facility)
        {
            if (id != facility.Id)
                return BadRequest();

            _facilityService.UpdateFacility(facility);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFacility(Guid id)
        {
            _facilityService.DeleteFacility(id);
            return NoContent();
        }
    }
}