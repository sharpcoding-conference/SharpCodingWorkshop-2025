using MedicalRecords.Application.Services;
using MedicalRecords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecords.API.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(Guid id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            _patientService.CreatePatient(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(Guid id, [FromBody] Patient patient)
        {
            if (id != patient.Id)
                return BadRequest();

            _patientService.UpdatePatient(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(Guid id)
        {
            _patientService.DeletePatient(id);
            return NoContent();
        }

        [HttpPost("{patientId}/anonymize")]
        public IActionResult AnonymizePatient(Guid patientId)
        {
            _patientService.AnonymizePatient(patientId);
            _diagnosisService.AnonymizePatientDiagnoses(patientId);
            return Ok(new { message = "Dati paziente e diagnosi anonimizzati con successo." });
        }
    }
}