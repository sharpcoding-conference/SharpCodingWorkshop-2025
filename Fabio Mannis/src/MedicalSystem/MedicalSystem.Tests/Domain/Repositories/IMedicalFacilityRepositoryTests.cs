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
    public class IMedicalFacilityRepositoryTests
    {
        private readonly Mock<IMedicalFacilityRepository> _mockMedicalFacilityRepository;

        public IMedicalFacilityRepositoryTests()
        {
            _mockMedicalFacilityRepository = new Mock<IMedicalFacilityRepository>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_MedicalFacility_When_Exists()
        {
            // Arrange
            var facilityId = Guid.NewGuid();
            var expectedFacility = new MedicalFacility
            {
                Id = facilityId,
                Name = "Central Hospital",
                Address = "123 Main St",
                Phone = "1234567890"
            };

            _mockMedicalFacilityRepository.Setup(repo => repo.GetByIdAsync(facilityId))
                .ReturnsAsync(expectedFacility);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.GetByIdAsync(facilityId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(facilityId);
            result.Name.Should().Be("Central Hospital");
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            var facilityId = Guid.NewGuid();
            _mockMedicalFacilityRepository.Setup(repo => repo.GetByIdAsync(facilityId))
                .ReturnsAsync((MedicalFacility)null);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.GetByIdAsync(facilityId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_List_Of_Facilities()
        {
            // Arrange
            var facilities = new List<MedicalFacility>
            {
                new MedicalFacility { Id = Guid.NewGuid(), Name = "Central Hospital", Address = "123 Main St" },
                new MedicalFacility { Id = Guid.NewGuid(), Name = "City Clinic", Address = "456 Elm St" }
            };

            _mockMedicalFacilityRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(facilities);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(f => f.Name == "Central Hospital");
            result.Should().Contain(f => f.Name == "City Clinic");
        }

        [Fact]
        public async Task GetByNameAsync_Should_Return_Correct_Facility()
        {
            // Arrange
            var facilityName = "Central Hospital";
            var expectedFacility = new MedicalFacility
            {
                Id = Guid.NewGuid(),
                Name = facilityName,
                Address = "123 Main St"
            };

            _mockMedicalFacilityRepository.Setup(repo => repo.GetByNameAsync(facilityName))
                .ReturnsAsync(expectedFacility);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.GetByNameAsync(facilityName);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(facilityName);
        }

        [Fact]
        public async Task GetByNameAsync_Should_Return_Null_If_Not_Found()
        {
            // Arrange
            var facilityName = "NonExistent Facility";
            _mockMedicalFacilityRepository.Setup(repo => repo.GetByNameAsync(facilityName))
                .ReturnsAsync((MedicalFacility)null);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.GetByNameAsync(facilityName);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetDoctorsByFacilityIdAsync_Should_Return_Correct_Doctors()
        {
            // Arrange
            var facilityId = Guid.NewGuid();
            var doctors = new List<Doctor>
            {
                new Doctor { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", Specialization = "Cardiology" },
                new Doctor { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Jones", Specialization = "Neurology" }
            };

            _mockMedicalFacilityRepository.Setup(repo => repo.GetDoctorsByFacilityIdAsync(facilityId))
                .ReturnsAsync(doctors);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.GetDoctorsByFacilityIdAsync(facilityId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(d => d.Specialization == "Cardiology");
            result.Should().Contain(d => d.Specialization == "Neurology");
        }

        [Fact]
        public async Task ExistsByNameAsync_Should_Return_True_If_Exists()
        {
            // Arrange
            var facilityName = "Central Hospital";
            _mockMedicalFacilityRepository.Setup(repo => repo.ExistsByNameAsync(facilityName))
                .ReturnsAsync(true);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.ExistsByNameAsync(facilityName);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task ExistsByNameAsync_Should_Return_False_If_Not_Exists()
        {
            // Arrange
            var facilityName = "Unknown Facility";
            _mockMedicalFacilityRepository.Setup(repo => repo.ExistsByNameAsync(facilityName))
                .ReturnsAsync(false);

            // Act
            var result = await _mockMedicalFacilityRepository.Object.ExistsByNameAsync(facilityName);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task AddAsync_Should_Add_New_MedicalFacility()
        {
            // Arrange
            var newFacility = new MedicalFacility
            {
                Id = Guid.NewGuid(),
                Name = "New Medical Center",
                Address = "789 Oak St"
            };

            _mockMedicalFacilityRepository.Setup(repo => repo.AddAsync(newFacility))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockMedicalFacilityRepository.Object.AddAsync(newFacility);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_MedicalFacility()
        {
            // Arrange
            var facility = new MedicalFacility
            {
                Id = Guid.NewGuid(),
                Name = "Updated Facility",
                Address = "Updated Address"
            };

            _mockMedicalFacilityRepository.Setup(repo => repo.UpdateAsync(facility))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockMedicalFacilityRepository.Object.UpdateAsync(facility);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_MedicalFacility()
        {
            // Arrange
            var facilityId = Guid.NewGuid();

            _mockMedicalFacilityRepository.Setup(repo => repo.DeleteAsync(facilityId))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockMedicalFacilityRepository.Object.DeleteAsync(facilityId);

            // Assert
            await act.Should().NotThrowAsync();
        }
    }
}
