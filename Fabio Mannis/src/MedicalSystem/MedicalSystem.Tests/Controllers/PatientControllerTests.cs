using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using MedicalSystem.Application.DTOs;
using Xunit;

namespace MedicalSystem.API.IntegrationTests.Controllers
{
    public class PatientControllerTests : IClassFixture<TestStartup>
    {
        private readonly HttpClient _client;

        public PatientControllerTests(TestStartup factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllPatients_ShouldReturnEmptyList_WhenNoPatientsExist()
        {
            // Act
            var response = await _client.GetAsync("/api/patients");
            var patients = await response.Content.ReadFromJsonAsync<PatientDto[]>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            patients.Should().BeEmpty();
        }

        [Fact]
        public async Task AddPatient_ShouldReturnCreated_WhenValidRequest()
        {
            // Arrange
            var newPatient = new PatientDto
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                TaxCode = "ABC123XYZ",
                Email = "john.doe@example.com",
                Phone = "1234567890"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/patients", newPatient);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetPatientById_ShouldReturnNotFound_WhenPatientDoesNotExist()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act
            var response = await _client.GetAsync($"/api/patients/{nonExistentId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
