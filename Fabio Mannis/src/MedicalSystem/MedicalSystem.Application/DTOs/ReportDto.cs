using System;
using MedicalSystem.Domain.Enums;

namespace MedicalSystem.Application.DTOs
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public Guid DiagnosisId { get; set; }
        public ReportType Type { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}