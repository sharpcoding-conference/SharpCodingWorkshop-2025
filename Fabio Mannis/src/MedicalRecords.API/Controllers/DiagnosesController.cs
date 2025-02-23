using MedicalRecords.Application.Services;
using MedicalRecords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecords.API.Controllers
{
    [Route("api/diagnoses")]
    [ApiController]
    public class DiagnosesController : ControllerBase
    {
        private readonly DiagnosisService _diagnosisService;

        public DiagnosesController(DiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }

        [HttpGet("patient/{patientId}")]
        public IActionResult GetDiagnosesByPatient(Guid patientId)
        {
            var diagnoses = _diagnosisService.GetDiagnosesByPatient(patientId);
            return Ok(diagnoses);
        }

    }
}