using FluentAssertions;
using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Tests.Domain.Entities
{
    public class PatientTests
    {
        [Fact]
        public void Patient_Should_Have_Default_Values()
        {
            // Arrange & Act
            var patient = new Patient();

            // Assert
            patient.Id.Should().NotBeEmpty();
            patient.Appointments.Should().BeEmpty();
        }

        [Fact]
        public void Patient_Should_Store_Correct_Data()
        {
            // Arrange
            var patient = new Patient
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                TaxCode = "ABC123456",
                Email = "john.doe@example.com",
                Phone = "1234567890"
            };

            // Act & Assert
            patient.FirstName.Should().Be("John");
            patient.LastName.Should().Be("Doe");
            patient.DateOfBirth.Should().Be(new DateTime(1990, 1, 1));
            patient.TaxCode.Should().Be("ABC123456");
            patient.Email.Should().Be("john.doe@example.com");
            patient.Phone.Should().Be("1234567890");
        }
    }
}