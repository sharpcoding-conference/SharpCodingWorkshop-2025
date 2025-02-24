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
    public class IDiagnosisRepositoryTests
    {
        private readonly Mock<IDiagnosisRepository> _mockDiagnosisRepository;

        public IDiagnosisRepositoryTests()
        {
            _mockDiagnosisRepository = new Mock<IDiagnosisRepository>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Diagnosis_When_Exists()
        {
            // Arrange
            var diagnosisId = Guid.NewGuid();
            var expectedDiagnosis = new Diagnosis
            {
                Id = diagnosisId,
                AppointmentId = Guid.NewGuid(),
                Description = "Hypertension diagnosis"
            };

            _mockDiagnosisRepository.Setup(repo => repo.GetByIdAsync(diagnosisId))
                .ReturnsAsync(expectedDiagnosis);

            // Act
            var result = await _mockDiagnosisRepository.Object.GetByIdAsync(diagnosisId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(diagnosisId);
            result.Description.Should().Be("Hypertension diagnosis");
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            var diagnosisId = Guid.NewGuid();
            _mockDiagnosisRepository.Setup(repo => repo.GetByIdAsync(diagnosisId))
                .ReturnsAsync((Diagnosis)null);

            // Act
            var result = await _mockDiagnosisRepository.Object.GetByIdAsync(diagnosisId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_List_Of_Diagnoses()
        {
            // Arrange
            var diagnoses = new List<Diagnosis>
            {
                new Diagnosis { Id = Guid.NewGuid(), Description = "Diabetes Type 2" },
                new Diagnosis { Id = Guid.NewGuid(), Description = "Chronic Asthma" }
            };

            _mockDiagnosisRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(diagnoses);

            // Act
            var result = await _mockDiagnosisRepository.Object.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(d => d.Description == "Diabetes Type 2");
            result.Should().Contain(d => d.Description == "Chronic Asthma");
        }

        [Fact]
        public async Task GetByAppointmentIdAsync_Should_Return_Correct_Diagnosis()
        {
            // Arrange
            var appointmentId = Guid.NewGuid();
            var expectedDiagnosis = new Diagnosis
            {
                Id = Guid.NewGuid(),
                AppointmentId = appointmentId,
                Description = "Flu diagnosis"
            };

            _mockDiagnosisRepository.Setup(repo => repo.GetByAppointmentIdAsync(appointmentId))
                .ReturnsAsync(expectedDiagnosis);

            // Act
            var result = await _mockDiagnosisRepository.Object.GetByAppointmentIdAsync(appointmentId);

            // Assert
            result.Should().NotBeNull();
            result.AppointmentId.Should().Be(appointmentId);
            result.Description.Should().Be("Flu diagnosis");
        }

        [Fact]
        public async Task GetByAppointmentIdAsync_Should_Return_Null_If_Not_Found()
        {
            // Arrange
            var appointmentId = Guid.NewGuid();
            _mockDiagnosisRepository.Setup(repo => repo.GetByAppointmentIdAsync(appointmentId))
                .ReturnsAsync((Diagnosis)null);

            // Act
            var result = await _mockDiagnosisRepository.Object.GetByAppointmentIdAsync(appointmentId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetDiagnosesByPatientIdAsync_Should_Return_Correct_Diagnoses()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var diagnoses = new List<Diagnosis>
            {
                new Diagnosis { Id = Guid.NewGuid(), AppointmentId = Guid.NewGuid(), Description = "Migraine" },
                new Diagnosis { Id = Guid.NewGuid(), AppointmentId = Guid.NewGuid(), Description = "Allergy Reaction" }
            };

            _mockDiagnosisRepository.Setup(repo => repo.GetDiagnosesByPatientIdAsync(patientId))
                .ReturnsAsync(diagnoses);

            // Act
            var result = await _mockDiagnosisRepository.Object.GetDiagnosesByPatientIdAsync(patientId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(d => d.Description == "Migraine");
            result.Should().Contain(d => d.Description == "Allergy Reaction");
        }

        [Fact]
        public async Task AddAsync_Should_Add_New_Diagnosis()
        {
            // Arrange
            var newDiagnosis = new Diagnosis
            {
                Id = Guid.NewGuid(),
                AppointmentId = Guid.NewGuid(),
                Description = "Skin Rash"
            };

            _mockDiagnosisRepository.Setup(repo => repo.AddAsync(newDiagnosis))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockDiagnosisRepository.Object.AddAsync(newDiagnosis);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Diagnosis()
        {
            // Arrange
            var diagnosis = new Diagnosis
            {
                Id = Guid.NewGuid(),
                AppointmentId = Guid.NewGuid(),
                Description = "Updated Diagnosis"
            };

            _mockDiagnosisRepository.Setup(repo => repo.UpdateAsync(diagnosis))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockDiagnosisRepository.Object.UpdateAsync(diagnosis);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Diagnosis()
        {
            // Arrange
            var diagnosisId = Guid.NewGuid();

            _mockDiagnosisRepository.Setup(repo => repo.DeleteAsync(diagnosisId))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockDiagnosisRepository.Object.DeleteAsync(diagnosisId);

            // Assert
            await act.Should().NotThrowAsync();
        }
    }
}
