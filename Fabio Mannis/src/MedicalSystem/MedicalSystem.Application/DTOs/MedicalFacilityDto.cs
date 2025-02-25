using System;

namespace MedicalSystem.Application.DTOs
{
    public class MedicalFacilityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}