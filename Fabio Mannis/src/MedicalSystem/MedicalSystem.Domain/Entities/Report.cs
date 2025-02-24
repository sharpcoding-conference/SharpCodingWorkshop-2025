using MedicalSystem.Domain.Enums;

namespace MedicalSystem.Domain.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public ReportType Type { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}