using Microsoft.Extensions.DependencyInjection;
using MedicalSystem.Application.Interfaces;
using MedicalSystem.Application.Services;
using MedicalSystem.Application.Mapping;

namespace MedicalSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IMedicalFacilityService, MedicalFacilityService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<IReportService, ReportService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}