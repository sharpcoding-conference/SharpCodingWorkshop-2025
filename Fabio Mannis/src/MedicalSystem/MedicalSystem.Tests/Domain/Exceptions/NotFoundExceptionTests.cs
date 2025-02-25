using FluentAssertions;
using MedicalSystem.Domain.Exceptions;

namespace MedicalSystem.Tests.Domain.Exceptions
{
    public class NotFoundExceptionTests
    {
        [Fact]
        public void NotFoundException_Should_Have_Message()
        {
            // Arrange & Act
            var exception = new NotFoundException("Patient not found");

            // Assert
            exception.Message.Should().Be("Patient not found");
        }
    }
}