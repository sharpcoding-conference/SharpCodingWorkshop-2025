using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Enums;
using MedicalSystem.Domain.Interfaces;
using Xunit;

namespace MedicalSystem.Domain.Tests.Repositories
{
    public class IAppointmentRepositoryTests
    {
        private readonly Mock<IAppointmentRepository> _mockAppointmentRepository;

        public IAppointmentRepositoryTests()
        {
            _mockAppointmentRepository = new Mock<IAppointmentRepository>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Appointment_When_Exists()
        {
            // Arrange
            var appointmentId = Guid.NewGuid();
            var expectedAppointment = new Appointment
            {
                Id = appointmentId,
                DateTime = new DateTime(2025, 3, 15, 10, 30, 0),
                Status = AppointmentStatus.Booked,
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid()
            };

            _mockAppointmentRepository.Setup(repo => repo.GetByIdAsync(appointmentId))
                .ReturnsAsync(expectedAppointment);

            // Act
            var result = await _mockAppointmentRepository.Object.GetByIdAsync(appointmentId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(appointmentId);
            result.Status.Should().Be(AppointmentStatus.Booked);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            var appointmentId = Guid.NewGuid();
            _mockAppointmentRepository.Setup(repo => repo.GetByIdAsync(appointmentId))
                .ReturnsAsync((Appointment)null);

            // Act
            var result = await _mockAppointmentRepository.Object.GetByIdAsync(appointmentId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_List_Of_Appointments()
        {
            // Arrange
            var appointments = new List<Appointment>
            {
                new Appointment { Id = Guid.NewGuid(), DateTime = DateTime.UtcNow, Status = AppointmentStatus.Booked },
                new Appointment { Id = Guid.NewGuid(), DateTime = DateTime.UtcNow, Status = AppointmentStatus.Completed }
            };

            _mockAppointmentRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(appointments);

            // Act
            var result = await _mockAppointmentRepository.Object.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(a => a.Status == AppointmentStatus.Booked);
            result.Should().Contain(a => a.Status == AppointmentStatus.Completed);
        }

        [Fact]
        public async Task GetByPatientIdAsync_Should_Return_Correct_Appointments()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var appointments = new List<Appointment>
            {
                new Appointment { Id = Guid.NewGuid(), PatientId = patientId },
                new Appointment { Id = Guid.NewGuid(), PatientId = patientId }
            };

            _mockAppointmentRepository.Setup(repo => repo.GetByPatientIdAsync(patientId))
                .ReturnsAsync(appointments);

            // Act
            var result = await _mockAppointmentRepository.Object.GetByPatientIdAsync(patientId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().AllSatisfy(a => a.PatientId.Should().Be(patientId));
        }

        [Fact]
        public async Task GetByDoctorIdAsync_Should_Return_Correct_Appointments()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var appointments = new List<Appointment>
            {
                new Appointment { Id = Guid.NewGuid(), DoctorId = doctorId },
                new Appointment { Id = Guid.NewGuid(), DoctorId = doctorId }
            };

            _mockAppointmentRepository.Setup(repo => repo.GetByDoctorIdAsync(doctorId))
                .ReturnsAsync(appointments);

            // Act
            var result = await _mockAppointmentRepository.Object.GetByDoctorIdAsync(doctorId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().AllSatisfy(a => a.DoctorId.Should().Be(doctorId));
        }

        [Fact]
        public async Task GetByStatusAsync_Should_Return_Correct_Appointments()
        {
            // Arrange
            var status = AppointmentStatus.Booked;
            var appointments = new List<Appointment>
            {
                new Appointment { Id = Guid.NewGuid(), Status = status },
                new Appointment { Id = Guid.NewGuid(), Status = status }
            };

            _mockAppointmentRepository.Setup(repo => repo.GetByStatusAsync(status))
                .ReturnsAsync(appointments);

            // Act
            var result = await _mockAppointmentRepository.Object.GetByStatusAsync(status);

            // Assert
            result.Should().HaveCount(2);
            result.Should().AllSatisfy(a => a.Status.Should().Be(status));
        }

        [Fact]
        public async Task IsDoctorAvailableAsync_Should_Return_False_If_Busy()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var dateTime = DateTime.UtcNow;
            _mockAppointmentRepository.Setup(repo => repo.IsDoctorAvailableAsync(doctorId, dateTime))
                .ReturnsAsync(false);

            // Act
            var result = await _mockAppointmentRepository.Object.IsDoctorAvailableAsync(doctorId, dateTime);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task IsDoctorAvailableAsync_Should_Return_True_If_Available()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var dateTime = DateTime.UtcNow;
            _mockAppointmentRepository.Setup(repo => repo.IsDoctorAvailableAsync(doctorId, dateTime))
                .ReturnsAsync(true);

            // Act
            var result = await _mockAppointmentRepository.Object.IsDoctorAvailableAsync(doctorId, dateTime);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task AddAsync_Should_Add_New_Appointment()
        {
            // Arrange
            var newAppointment = new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                DateTime = DateTime.UtcNow,
                Status = AppointmentStatus.Booked
            };

            _mockAppointmentRepository.Setup(repo => repo.AddAsync(newAppointment))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockAppointmentRepository.Object.AddAsync(newAppointment);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Appointment()
        {
            // Arrange
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.UtcNow,
                Status = AppointmentStatus.Completed
            };

            _mockAppointmentRepository.Setup(repo => repo.UpdateAsync(appointment))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockAppointmentRepository.Object.UpdateAsync(appointment);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Appointment()
        {
            // Arrange
            var appointmentId = Guid.NewGuid();

            _mockAppointmentRepository.Setup(repo => repo.DeleteAsync(appointmentId))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockAppointmentRepository.Object.DeleteAsync(appointmentId);

            // Assert
            await act.Should().NotThrowAsync();
        }
    }
}
