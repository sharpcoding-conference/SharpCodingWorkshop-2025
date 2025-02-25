using System;
using System.Collections.Generic;
using MedicalSystem.Application.DTOs;

namespace MedicalSystem.Application.DTOs
{
    public class DiagnosisDto
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public string Description { get; set; }
        public List<ReportDto> Reports { get; set; } = new List<ReportDto>();
    }
}