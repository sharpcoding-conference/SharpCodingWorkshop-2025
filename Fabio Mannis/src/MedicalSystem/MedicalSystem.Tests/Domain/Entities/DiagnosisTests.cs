using System;
using System.Collections.Generic;
using FluentAssertions;
using MedicalSystem.Domain.Entities;
using Xunit;

namespace MedicalSystem.Domain.Tests.Entities
{
    public class DiagnosisTests
    {
        [Fact]
        public void Diagnosis_Should_Have_Default_Values()
        {
            // Arrange & Act
            var diagnosis = new Diagnosis();

            // Assert
            diagnosis.Id.Should().NotBeEmpty();
            diagnosis.Reports.Should().BeEmpty();
        }

        [Fact]
        public void Diagnosis_Should_Store_Correct_Data()
        {
            // Arrange
            var appointment = new Appointment { Id = Guid.NewGuid() };
            var diagnosis = new Diagnosis
            {
                Id = Guid.NewGuid(),
                AppointmentId = appointment.Id,
                Appointment = appointment,
                Description = "Hypertension diagnosis"
            };

            // Act & Assert
            diagnosis.AppointmentId.Should().Be(appointment.Id);
            diagnosis.Appointment.Should().Be(appointment);
            diagnosis.Description.Should().Be("Hypertension diagnosis");
        }

        [Fact]
        public void Diagnosis_Should_Contain_Reports()
        {
            // Arrange
            var diagnosis = new Diagnosis { Id = Guid.NewGuid() };
            var report1 = new Report { Id = Guid.NewGuid(), DiagnosisId = diagnosis.Id, FilePath = "/reports/report1.pdf" };
            var report2 = new Report { Id = Guid.NewGuid(), DiagnosisId = diagnosis.Id, FilePath = "/reports/report2.pdf" };

            // Act
            diagnosis.Reports.Add(report1);
            diagnosis.Reports.Add(report2);

            // Assert
            diagnosis.Reports.Should().HaveCount(2);
            diagnosis.Reports.Should().Contain(report1);
            diagnosis.Reports.Should().Contain(report2);
        }

        [Fact]
        public void Diagnosis_With_No_Description_Should_Throw_Exception()
        {
            // Arrange
            var diagnosis = new Diagnosis { Id = Guid.NewGuid(), Description = "" };

            // Act & Assert
            diagnosis.Description.Should().NotBeNullOrEmpty("Diagnosis description is required.");
        }
    }
}
