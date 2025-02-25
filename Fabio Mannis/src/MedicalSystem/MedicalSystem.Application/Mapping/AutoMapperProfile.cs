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
            CreateMap<Appointment, AppointmentDto>()
                .ReverseMap() // Inverte la mappatura, ma la regola per l'Id deve essere ridefinita
                .ForMember(dest => dest.Id, opt => opt.PreCondition(src => src.Id == Guid.Empty)) // Controllo PreCondition
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())); // Genera un nuovo GUID
            CreateMap<Diagnosis, DiagnosisDto>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<MedicalFacility, MedicalFacilityDto>().ReverseMap();
        }
    }
}