using FluentAssertions;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Enums;

namespace MedicalSystem.Tests.Domain.Entities
{
    public class ReportTests
    {
        [Fact]
        public void Report_Should_Have_Default_Values()
        {
            // Arrange & Act
            var report = new Report();

            // Assert
            report.Id.Should().NotBeEmpty();
            report.FilePath.Should().BeNull();
            report.CreatedAt.Should().Be(default);
        }

        [Fact]
        public void Report_Should_Store_Correct_Data()
        {
            // Arrange
            var diagnosis = new Diagnosis { Id = Guid.NewGuid() };
            var report = new Report
            {
                Id = Guid.NewGuid(),
                DiagnosisId = diagnosis.Id,
                Diagnosis = diagnosis,
                Type = ReportType.Laboratory,
                FilePath = "/reports/lab_test.pdf",
                CreatedAt = new DateTime(2025, 3, 15, 10, 30, 0)
            };

            // Act & Assert
            report.DiagnosisId.Should().Be(diagnosis.Id);
            report.Diagnosis.Should().Be(diagnosis);
            report.Type.Should().Be(ReportType.Laboratory);
            report.FilePath.Should().Be("/reports/lab_test.pdf");
            report.CreatedAt.Should().Be(new DateTime(2025, 3, 15, 10, 30, 0));
        }

        [Fact]
        public void Report_FilePath_Should_Not_Be_Empty()
        {
            // Arrange
            var report = new Report { FilePath = "" };

            // Act & Assert
            report.FilePath.Should().NotBeNullOrEmpty("Report file path is required.");
        }

        [Fact]
        public void Report_Type_Should_Be_Valid()
        {
            // Arrange
            var report = new Report { Type = ReportType.Cardiology };

            // Act & Assert
            report.Type.Should().Be(ReportType.Cardiology);
        }
    }
}
