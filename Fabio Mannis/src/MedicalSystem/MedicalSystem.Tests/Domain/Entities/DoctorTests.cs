using FluentAssertions;
using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Tests.Domain.Entities
{
    public class DoctorTests
    {
        [Fact]
        public void Doctor_Should_Have_Default_Values()
        {
            // Arrange & Act
            var doctor = new Doctor();

            // Assert
            doctor.Id.Should().NotBeEmpty();
            doctor.Appointments.Should().BeEmpty();
        }

        [Fact]
        public void Doctor_Should_Store_Correct_Data()
        {
            // Arrange
            var doctor = new Doctor
            {
                FirstName = "Alice",
                LastName = "Smith",
                Specialization = "Cardiology",
                Email = "alice.smith@example.com",
                Phone = "0987654321"
            };

            // Act & Assert
            doctor.FirstName.Should().Be("Alice");
            doctor.LastName.Should().Be("Smith");
            doctor.Specialization.Should().Be("Cardiology");
            doctor.Email.Should().Be("alice.smith@example.com");
            doctor.Phone.Should().Be("0987654321");
        }
    }
}