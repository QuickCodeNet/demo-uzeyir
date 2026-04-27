using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.PendingTransfer;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.PendingTransfer;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Tests.Services.PendingTransfer
{
    public class InsertPendingTransferCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IPendingTransferRepository> _repositoryMock;
        private readonly Mock<ILogger<PendingTransferService>> _loggerMock;
        private readonly PendingTransferService _service;
        public InsertPendingTransferCommandTests()
        {
            _repositoryMock = new Mock<IPendingTransferRepository>();
            _loggerMock = new Mock<ILogger<PendingTransferService>>();
            _service = new PendingTransferService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<PendingTransferDto>("tr");
            var fakeResponse = new RepoResponse<PendingTransferDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<PendingTransferDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<PendingTransferDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<PendingTransferDto>("tr");
            var fakeResponse = new RepoResponse<PendingTransferDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<PendingTransferDto>())).ReturnsAsync(fakeResponse);
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