﻿using System;

namespace MedicalSystem.Application.DTOs
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid MedicalFacilityId { get; set; }
    }
}