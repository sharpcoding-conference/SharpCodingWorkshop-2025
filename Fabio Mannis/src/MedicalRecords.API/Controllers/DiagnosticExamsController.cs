using MedicalRecords.Application.Services;
using MedicalRecords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecords.API.Controllers
{
    [Route("api/diagnosticexams")]
    [ApiController]
    public class DiagnosticExamsController : ControllerBase
    {
        private readonly DiagnosticExamService _examService;

        public DiagnosticExamsController(DiagnosticExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public IActionResult GetAllExams()
        {
            var exams = _examService.GetAllExams();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public IActionResult GetExamById(Guid id)
        {
            var exam = _examService.GetExamById(id);
            if (exam == null)
                return NotFound();
            return Ok(exam);
        }

        [HttpGet("patient/{patientId}")]
        public IActionResult GetExamsByPatient(Guid patientId)
        {
            var exams = _examService.GetExamsByPatient(patientId);
            return Ok(exams);
        }

        [HttpPost]
        public IActionResult CreateExam([FromBody] DiagnosticExam exam)
        {
            _examService.CreateExam(exam);
            return CreatedAtAction(nameof(GetExamById), new { id = exam.Id }, exam);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExam(Guid id, [FromBody] DiagnosticExam exam)
        {
            if (id != exam.Id)
                return BadRequest();

            _examService.UpdateExam(exam);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExam(Guid id)
        {
            _examService.DeleteExam(id);
            return NoContent();
        }
    }
}