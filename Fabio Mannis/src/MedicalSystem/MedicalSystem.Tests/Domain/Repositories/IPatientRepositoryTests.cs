using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Interfaces;
using Xunit;

namespace MedicalSystem.Domain.Tests.Repositories
{
    public class IPatientRepositoryTests
    {
        private readonly Mock<IPatientRepository> _mockPatientRepository;

        public IPatientRepositoryTests()
        {
            _mockPatientRepository = new Mock<IPatientRepository>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Patient_When_Exists()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var expectedPatient = new Patient
            {
                Id = patientId,
                FirstName = "John",
                LastName = "Doe",
                TaxCode = "ABC123456",
                Email = "john.doe@example.com",
                Phone = "1234567890"
            };

            _mockPatientRepository.Setup(repo => repo.GetByIdAsync(patientId))
                .ReturnsAsync(expectedPatient);

            // Act
            var result = await _mockPatientRepository.Object.GetByIdAsync(patientId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(patientId);
            result.FirstName.Should().Be("John");
            result.TaxCode.Should().Be("ABC123456");
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            _mockPatientRepository.Setup(repo => repo.GetByIdAsync(patientId))
                .ReturnsAsync((Patient)null);

            // Act
            var result = await _mockPatientRepository.Object.GetByIdAsync(patientId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_List_Of_Patients()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", TaxCode = "TAX001" },
                new Patient { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Jones", TaxCode = "TAX002" }
            };

            _mockPatientRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(patients);

            // Act
            var result = await _mockPatientRepository.Object.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(p => p.TaxCode == "TAX001");
            result.Should().Contain(p => p.TaxCode == "TAX002");
        }

        [Fact]
        public async Task GetByTaxCodeAsync_Should_Return_Correct_Patient()
        {
            // Arrange
            var taxCode = "TAX123";
            var expectedPatient = new Patient
            {
                Id = Guid.NewGuid(),
                FirstName = "Charlie",
                LastName = "Brown",
                TaxCode = taxCode
            };

            _mockPatientRepository.Setup(repo => repo.GetByTaxCodeAsync(taxCode))
                .ReturnsAsync(expectedPatient);

            // Act
            var result = await _mockPatientRepository.Object.GetByTaxCodeAsync(taxCode);

            // Assert
            result.Should().NotBeNull();
            result.TaxCode.Should().Be(taxCode);
        }

        [Fact]
        public async Task GetByTaxCodeAsync_Should_Return_Null_If_Not_Found()
        {
            // Arrange
            var taxCode = "INVALID_TAX_CODE";
            _mockPatientRepository.Setup(repo => repo.GetByTaxCodeAsync(taxCode))
                .ReturnsAsync((Patient)null);

            // Act
            var result = await _mockPatientRepository.Object.GetByTaxCodeAsync(taxCode);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task AddAsync_Should_Add_New_Patient()
        {
            // Arrange
            var newPatient = new Patient
            {
                Id = Guid.NewGuid(),
                FirstName = "Eve",
                LastName = "Williams",
                TaxCode = "NEW_TAX_CODE"
            };

            _mockPatientRepository.Setup(repo => repo.AddAsync(newPatient))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockPatientRepository.Object.AddAsync(newPatient);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Patient()
        {
            // Arrange
            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                FirstName = "David",
                LastName = "Lee",
                TaxCode = "UPDATE_TAX_CODE"
            };

            _mockPatientRepository.Setup(repo => repo.UpdateAsync(patient))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockPatientRepository.Object.UpdateAsync(patient);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Patient()
        {
            // Arrange
            var patientId = Guid.NewGuid();

            _mockPatientRepository.Setup(repo => repo.DeleteAsync(patientId))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockPatientRepository.Object.DeleteAsync(patientId);

            // Assert
            await act.Should().NotThrowAsync();
        }
    }
}
