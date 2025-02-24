using AutoMapper;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping between Domain Entities and DTOs
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Diagnosis, DiagnosisDto>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<MedicalFacility, MedicalFacilityDto>().ReverseMap();
        }
    }
}