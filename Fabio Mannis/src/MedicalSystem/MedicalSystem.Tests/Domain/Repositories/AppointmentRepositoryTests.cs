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
    public class AppointmentRepositoryTests
    {
        private readonly Mock<IAppointmentRepository> _mockRepo;

        public AppointmentRepositoryTests()
        {
            _mockRepo = new Mock<IAppointmentRepository>();
        }

        [Fact]
        public async Task GetByPatientIdAsync_Should_Return_Appointments()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var appointments = new List<Appointment>
            {
                new Appointment { Id = Guid.NewGuid(), PatientId = patientId },
                new Appointment { Id = Guid.NewGuid(), PatientId = patientId }
            };

            _mockRepo.Setup(repo => repo.GetByPatientIdAsync(patientId))
                .ReturnsAsync(appointments);

            // Act
            var result = await _mockRepo.Object.GetByPatientIdAsync(patientId);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async Task IsDoctorAvailableAsync_Should_Return_False_If_Busy()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var dateTime = DateTime.UtcNow;
            _mockRepo.Setup(repo => repo.IsDoctorAvailableAsync(doctorId, dateTime))
                .ReturnsAsync(false);

            // Act
            var result = await _mockRepo.Object.IsDoctorAvailableAsync(doctorId, dateTime);

            // Assert
            result.Should().BeFalse();
        }
    }
}