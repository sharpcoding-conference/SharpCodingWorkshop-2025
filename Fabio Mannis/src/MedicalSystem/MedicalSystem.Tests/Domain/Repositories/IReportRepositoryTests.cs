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
    public class IReportRepositoryTests
    {
        private readonly Mock<IReportRepository> _mockReportRepository;

        public IReportRepositoryTests()
        {
            _mockReportRepository = new Mock<IReportRepository>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Report_When_Exists()
        {
            // Arrange
            var reportId = Guid.NewGuid();
            var expectedReport = new Report
            {
                Id = reportId,
                DiagnosisId = Guid.NewGuid(),
                Type = ReportType.Laboratory,
                FilePath = "/reports/lab_test.pdf",
                CreatedAt = DateTime.UtcNow
            };

            _mockReportRepository.Setup(repo => repo.GetByIdAsync(reportId))
                .ReturnsAsync(expectedReport);

            // Act
            var result = await _mockReportRepository.Object.GetByIdAsync(reportId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(reportId);
            result.Type.Should().Be(ReportType.Laboratory);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            var reportId = Guid.NewGuid();
            _mockReportRepository.Setup(repo => repo.GetByIdAsync(reportId))
                .ReturnsAsync((Report)null);

            // Act
            var result = await _mockReportRepository.Object.GetByIdAsync(reportId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_List_Of_Reports()
        {
            // Arrange
            var reports = new List<Report>
            {
                new Report { Id = Guid.NewGuid(), Type = ReportType.Cardiology, FilePath = "/reports/cardio1.pdf" },
                new Report { Id = Guid.NewGuid(), Type = ReportType.Radiology, FilePath = "/reports/radio1.pdf" }
            };

            _mockReportRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(reports);

            // Act
            var result = await _mockReportRepository.Object.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(r => r.Type == ReportType.Cardiology);
            result.Should().Contain(r => r.Type == ReportType.Radiology);
        }

        [Fact]
        public async Task GetByDiagnosisIdAsync_Should_Return_Correct_Reports()
        {
            // Arrange
            var diagnosisId = Guid.NewGuid();
            var reports = new List<Report>
            {
                new Report { Id = Guid.NewGuid(), DiagnosisId = diagnosisId, Type = ReportType.Laboratory },
                new Report { Id = Guid.NewGuid(), DiagnosisId = diagnosisId, Type = ReportType.Radiology }
            };

            _mockReportRepository.Setup(repo => repo.GetByDiagnosisIdAsync(diagnosisId))
                .ReturnsAsync(reports);

            // Act
            var result = await _mockReportRepository.Object.GetByDiagnosisIdAsync(diagnosisId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().AllSatisfy(r => r.DiagnosisId.Should().Be(diagnosisId));
        }

        [Fact]
        public async Task GetByDiagnosisIdAsync_Should_Return_Empty_List_If_Not_Found()
        {
            // Arrange
            var diagnosisId = Guid.NewGuid();
            _mockReportRepository.Setup(repo => repo.GetByDiagnosisIdAsync(diagnosisId))
                .ReturnsAsync(new List<Report>());

            // Act
            var result = await _mockReportRepository.Object.GetByDiagnosisIdAsync(diagnosisId);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task AddAsync_Should_Add_New_Report()
        {
            // Arrange
            var newReport = new Report
            {
                Id = Guid.NewGuid(),
                DiagnosisId = Guid.NewGuid(),
                Type = ReportType.Laboratory,
                FilePath = "/reports/lab_new.pdf",
                CreatedAt = DateTime.UtcNow
            };

            _mockReportRepository.Setup(repo => repo.AddAsync(newReport))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockReportRepository.Object.AddAsync(newReport);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Report()
        {
            // Arrange
            var report = new Report
            {
                Id = Guid.NewGuid(),
                DiagnosisId = Guid.NewGuid(),
                Type = ReportType.Cardiology,
                FilePath = "/reports/cardio_updated.pdf"
            };

            _mockReportRepository.Setup(repo => repo.UpdateAsync(report))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockReportRepository.Object.UpdateAsync(report);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Report()
        {
            // Arrange
            var reportId = Guid.NewGuid();

            _mockReportRepository.Setup(repo => repo.DeleteAsync(reportId))
                .Returns(Task.CompletedTask);

            // Act
            Func<Task> act = async () => await _mockReportRepository.Object.DeleteAsync(reportId);

            // Assert
            await act.Should().NotThrowAsync();
        }
    }
}
