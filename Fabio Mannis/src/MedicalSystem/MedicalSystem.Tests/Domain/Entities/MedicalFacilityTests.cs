using System;
using FluentAssertions;
using MedicalSystem.Domain.Entities;
using Xunit;

namespace MedicalSystem.Domain.Tests.Entities
{
    public class MedicalFacilityTests
    {
        [Fact]
        public void MedicalFacility_Should_Have_Default_Values()
        {
            var facility = new MedicalFacility();

            facility.Id.Should().NotBeEmpty();
            facility.Doctors.Should().BeEmpty();
        }
    }
}