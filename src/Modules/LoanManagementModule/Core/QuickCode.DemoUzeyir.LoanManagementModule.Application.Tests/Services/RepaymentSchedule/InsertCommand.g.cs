using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.RepaymentSchedule;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.RepaymentSchedule;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Tests.Services.RepaymentSchedule
{
    public class InsertRepaymentScheduleCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IRepaymentScheduleRepository> _repositoryMock;
        private readonly Mock<ILogger<RepaymentScheduleService>> _loggerMock;
        private readonly RepaymentScheduleService _service;
        public InsertRepaymentScheduleCommandTests()
        {
            _repositoryMock = new Mock<IRepaymentScheduleRepository>();
            _loggerMock = new Mock<ILogger<RepaymentScheduleService>>();
            _service = new RepaymentScheduleService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RepaymentScheduleDto>("tr");
            var fakeResponse = new RepoResponse<RepaymentScheduleDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<RepaymentScheduleDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<RepaymentScheduleDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RepaymentScheduleDto>("tr");
            var fakeResponse = new RepoResponse<RepaymentScheduleDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<RepaymentScheduleDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.Null(result.Value);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}