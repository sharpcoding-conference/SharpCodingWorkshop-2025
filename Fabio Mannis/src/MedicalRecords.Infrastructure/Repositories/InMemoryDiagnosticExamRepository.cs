using MedicalRecords.Domain.Entities;
using MedicalRecords.Domain.Interfaces;

namespace MedicalRecords.Infrastructure.Repositories
{
    public class InMemoryDiagnosticExamRepository : IDiagnosticExamRepository
    {
        private readonly List<DiagnosticExam> _exams = new();

        public IEnumerable<DiagnosticExam> GetAll() => _exams;

        public IEnumerable<DiagnosticExam> GetByPatientId(Guid patientId) =>
            _exams.Where(e => e.PatientId == patientId);

        public DiagnosticExam? GetById(Guid id) => _exams.FirstOrDefault(e => e.Id == id);

        public void Add(DiagnosticExam exam) => _exams.Add(exam);

        public void Update(DiagnosticExam exam)
        {
            var existingExam = GetById(exam.Id);
            if (existingExam != null)
            {
                existingExam.ExamType = exam.ExamType;
                existingExam.ExamDate = exam.ExamDate;
                existingExam.Result = exam.Result;
                existingExam.Report = exam.Report;
            }
        }

        public void Delete(Guid id) => _exams.RemoveAll(e => e.Id == id);
    }
}