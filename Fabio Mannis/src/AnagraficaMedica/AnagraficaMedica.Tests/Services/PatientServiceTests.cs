using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnagraficaMedica.Application.Services;
using AnagraficaMedica.Domain.Entities;
using AnagraficaMedica.Domain.Interfaces;
using Xunit;

namespace AnagraficaMedica.Tests.Services
{
    public class PatientServiceTests
    {
        private readonly Mock<IPatientRepository> _mockPatientRepository;
        private readonly PatientService _patientService;

        public PatientServiceTests()
        {
            _mockPatientRepository = new Mock<IPatientRepository>();
            _patientService = new PatientService(_mockPatientRepository.Object);
        }

        [Fact]
        public async Task GetAllPatientsAsync_ShouldReturnAllPatients()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient { FirstName = "Mario", LastName = "Rossi" },
                new Patient { FirstName = "Luca", LastName = "Bianchi" }
            };
            _mockPatientRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(patients);

            // Act
            var result = await _patientService.GetAllPatientsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPatientByIdAsync_ShouldReturnPatient_WhenPatientExists()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var patient = new Patient { Id = patientId, FirstName = "Mario", LastName = "Rossi" };
            _mockPatientRepository.Setup(repo => repo.GetByIdAsync(patientId)).ReturnsAsync(patient);

            // Act
            var result = await _patientService.GetPatientByIdAsync(patientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(patientId, result.Id);
        }

        [Fact]
        public async Task AddPatientAsync_ShouldCallAddAsync()
        {
            // Arrange
            var patient = new Patient { FirstName = "Anna", LastName = "Verdi" };

            // Act
            await _patientService.AddPatientAsync(patient);

            // Assert
            _mockPatientRepository.Verify(repo => repo.AddAsync(It.IsAny<Patient>()), Times.Once);
        }

        [Fact]
        public async Task DeletePatientAsync_ShouldCallDeleteAsync()
        {
            // Arrange
            var patientId = Guid.NewGuid();

            // Act
            await _patientService.DeletePatientAsync(patientId);

            // Assert
            _mockPatientRepository.Verify(repo => repo.DeleteAsync(patientId), Times.Once);
        }
    }
}
