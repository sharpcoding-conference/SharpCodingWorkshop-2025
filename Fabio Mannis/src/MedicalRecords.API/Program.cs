using MedicalRecords.Application.Services;
using MedicalRecords.Domain.Interfaces;
using MedicalRecords.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registrazione dei servizi
builder.Services.AddSingleton<IPatientRepository, InMemoryPatientRepository>();
builder.Services.AddSingleton<IDoctorRepository, InMemoryDoctorRepository>();
builder.Services.AddSingleton<IClinicalRecordRepository, InMemoryClinicalRecordRepository>();
builder.Services.AddSingleton<IHealthcareFacilityRepository, InMemoryHealthcareFacilityRepository>();
builder.Services.AddSingleton<IDiagnosticExamRepository, InMemoryDiagnosticExamRepository>();

builder.Services.AddSingleton<PatientService>();
builder.Services.AddSingleton<DoctorService>();
builder.Services.AddSingleton<MedicalRecordService>();
builder.Services.AddSingleton<MedicalFacilityService>();
builder.Services.AddSingleton<DiagnosticExamService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();