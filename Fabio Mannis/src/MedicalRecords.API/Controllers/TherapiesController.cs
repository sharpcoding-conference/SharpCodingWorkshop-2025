using MedicalRecords.Application.Services;
using MedicalRecords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecords.API.Controllers
{
    [Route("api/therapies")]
    [ApiController]
    public class TherapiesController : ControllerBase
    {
        private readonly TherapyService _therapyService;

        public TherapiesController(TherapyService therapyService)
        {
            _therapyService = therapyService;
        }

        [HttpGet("patient/{patientId}")]
        public IActionResult GetTherapiesByPatient(Guid patientId)
        {
            var therapies = _therapyService.GetByPatientId(patientId);
            return Ok(therapies);
        }
    }
}