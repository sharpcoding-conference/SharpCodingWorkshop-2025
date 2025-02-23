using MedicalRecords.Application.Services;
using MedicalRecords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecords.API.Controllers
{
    [Route("api/clinicalrecords")]
    [ApiController]
    public class ClinicalRecordsController : ControllerBase
    {
        private readonly MedicalRecordService _clinicalRecordService;

        public ClinicalRecordsController(MedicalRecordService clinicalRecordService)
        {
            _clinicalRecordService = clinicalRecordService;
        }

        [HttpGet]
        public IActionResult GetAllRecords()
        {
            var records = _clinicalRecordService.GetAllRecords();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecordById(Guid id)
        {
            var record = _clinicalRecordService.GetRecordById(id);
            if (record == null)
                return NotFound();
            return Ok(record);
        }

        [HttpGet("patient/{patientId}")]
        public IActionResult GetRecordsByPatient(Guid patientId)
        {
            var records = _clinicalRecordService.GetRecordsByPatient(patientId);
            return Ok(records);
        }

        [HttpPost]
        public IActionResult CreateRecord([FromBody] ClinicalRecord record)
        {
            _clinicalRecordService.CreateRecord(record);
            return CreatedAtAction(nameof(GetRecordById), new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecord(Guid id, [FromBody] ClinicalRecord record)
        {
            if (id != record.Id)
                return BadRequest();

            _clinicalRecordService.UpdateRecord(record);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(Guid id)
        {
            _clinicalRecordService.DeleteRecord(id);
            return NoContent();
        }
    }
}
