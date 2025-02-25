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
    public class IDoctorRepositoryTests
    {
        private readonly Mock<IDoctorRepository> _mockDoctorRepository;

        public IDoctorRepositoryTests()
        {
            _mockDoctorRepository = new Mock<IDoctorRepository>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Doctor_When_Exists()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var expectedDoctor = new Doctor
            {
                Id = doctorId,
                FirstName = "Alice",
                LastName = "Smith",
                Specialization = "Cardiology",
                Email = "alice.smith@example.com",
                Phone = "0987654321"
            };

            _mockDoctorRepository.Setup(repo => repo.GetByIdAsync(doctorId))
                .ReturnsAsync(expectedDoctor);

            // Act
            var result = await _mockDoctorRepository.Object.GetByIdAsync(doctorId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(doctorId);
            result.FirstName.Should().Be("Alice");
            result.Specialization.Should().Be("Cardiology");
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            _mockDoctorRepository.Setup(repo => repo.GetByIdAsync(doctorId))
                .ReturnsAsync((Doctor)null);

            // Act
            var result = await _mockDoctorRepository.Object.GetByIdAsync(doctorId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_List_Of_Doctors()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", Specialization = "Cardiology" },
                new Doctor { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Jones", Specialization = "Neurology" }
            };

            _mockDoctorRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(doctors);

            // Act
            var result = await _mockDoctorRepository.Object.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(d => d.Specialization == "Cardiology");
            result.Should().Contain(d => d.Specialization == "Neurology");
        }

        [Fact]
        public async Task GetBySpecializationAsync_Should_Return_Correct_Doctors()
        {
            // Arrange
            var specialization = "Cardiology";
            var doctors = new List<Doctor>
            {
                new Doctor { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", Specialization = specialization },
                new Doctor { Id = Guid.NewGuid(), FirstName = "Charlie", LastName = "Brown", Specialization = specialization }
            };

            _mockDoctorRepository.Setup(repo => repo.GetBySpecializationAsync(specialization))
                .ReturnsAsync(doctors);

            // Act
            var result = await _mockDoctorRepository.Object.GetBySpecializationAsync(specialization);

            // Assert
            result.Should().HaveCount(2);
            result.Should().AllSatisfy(d => d.Specialization.Should().Be(specialization));
        }

        [Fact]
        public async Task AddAsync_Should_Add_New_Doctor()
        {
            // Arrange
            var newDoctor = new Doctor
            {
                Id = Guid.NewGuid(),
                FirstName = "Eve",
                LastName = "Williams",
                Specialization = "Dermatology"
            };

            _mockDoctorRepository.Setup(repo => repo.AddAsync(newDoctor))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockDoctorRepository.Object.AddAsync(newDoctor);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Doctor()
        {
            // Arrange
            var doctor = new Doctor
            {
                Id = Guid.NewGuid(),
                FirstName = "David",
                LastName = "Lee",
                Specialization = "Orthopedics"
            };

            _mockDoctorRepository.Setup(repo => repo.UpdateAsync(doctor))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockDoctorRepository.Object.UpdateAsync(doctor);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Doctor()
        {
            // Arrange
            var doctorId = Guid.NewGuid();

            _mockDoctorRepository.Setup(repo => repo.DeleteAsync(doctorId))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockDoctorRepository.Object.DeleteAsync(doctorId);

            // Assert
            await act.Should().NotThrowAsync();
        }
    }
}
