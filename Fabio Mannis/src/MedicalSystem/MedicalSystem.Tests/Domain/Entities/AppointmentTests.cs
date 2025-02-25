using FluentAssertions;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Enums;

namespace MedicalSystem.Tests.Domain.Entities
{
    public class AppointmentTests
    {
        [Fact]
        public void Appointment_Should_Have_Default_Values()
        {
            // Arrange & Act
            var appointment = new Appointment();

            // Assert
            appointment.Id.Should().NotBeEmpty();
            appointment.Status.Should().Be(AppointmentStatus.Booked);
        }

        [Fact]
        public void Appointment_Should_Store_Correct_Data()
        {
            // Arrange
            var appointment = new Appointment
            {
                DateTime = new DateTime(2025, 3, 15, 10, 30, 0),
                Status = AppointmentStatus.Completed
            };

            // Act & Assert
            appointment.DateTime.Should().Be(new DateTime(2025, 3, 15, 10, 30, 0));
            appointment.Status.Should().Be(AppointmentStatus.Completed);
        }
    }
}