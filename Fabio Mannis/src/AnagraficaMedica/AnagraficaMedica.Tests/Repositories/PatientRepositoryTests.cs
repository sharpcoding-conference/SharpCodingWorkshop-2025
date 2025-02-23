using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AnagraficaMedica.Infrastructure.Persistence;
using AnagraficaMedica.Infrastructure.Repositories;
using AnagraficaMedica.Domain.Entities;
using Xunit;

namespace AnagraficaMedica.Tests.Repositories
{
    public class PatientRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly PatientRepository _patientRepository;

        public PatientRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);
            _patientRepository = new PatientRepository(_context);
        }

        [Fact]
        public async Task AddAsync_ShouldAddPatient()
        {
            // Arrange
            var patient = new Patient
            {
                FirstName = "Mario",
                LastName = "Rossi",
                DateOfBirth = new DateTime(1985, 6, 15),
                FiscalCode = "RSSMRA85H15L219K",
                Address = "Via Roma 10, Milano",
                PhoneNumber = "1234567890"
            };

            // Act
            await _patientRepository.AddAsync(patient);

            // Assert
            var addedPatient = await _context.Patients.FindAsync(patient.Id);
            Assert.NotNull(addedPatient);
            Assert.Equal("Marco", addedPatient.FirstName);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPatient_WhenPatientExists()
        {
            // Arrange
            var patient = new Patient
            {
                FirstName = "Mario",
                LastName = "Rossi",
                DateOfBirth = new DateTime(1985, 6, 15),
                FiscalCode = "RSSMRA85H15L219K",
                Address = "Via Roma 10, Milano",
                PhoneNumber = "1234567890"
            };
            await _patientRepository.AddAsync(patient);

            // Act
            var result = await _patientRepository.GetByIdAsync(patient.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(patient.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemovePatient()
        {
            // Arrange
            var patient = new Patient
            {
                FirstName = "Mario", LastName = "Rossi", DateOfBirth = new DateTime(1985, 6, 15),
                FiscalCode = "RSSMRA85H15L219K", Address = "Via Roma 10, Milano", PhoneNumber = "1234567890"
            };

            await _patientRepository.AddAsync(patient);

            // Act
            await _patientRepository.DeleteAsync(patient.Id);

            // Assert
            var deletedPatient = await _context.Patients.FindAsync(patient.Id);
            Assert.Null(deletedPatient);
        }
    }
}
