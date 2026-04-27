using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.TransactionChannel;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.TransactionChannel;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Tests.Services.TransactionChannel
{
    public class InsertTransactionChannelCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ITransactionChannelRepository> _repositoryMock;
        private readonly Mock<ILogger<TransactionChannelService>> _loggerMock;
        private readonly TransactionChannelService _service;
        public InsertTransactionChannelCommandTests()
        {
            _repositoryMock = new Mock<ITransactionChannelRepository>();
            _loggerMock = new Mock<ILogger<TransactionChannelService>>();
            _service = new TransactionChannelService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TransactionChannelDto>("tr");
            var fakeResponse = new RepoResponse<TransactionChannelDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<TransactionChannelDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<TransactionChannelDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TransactionChannelDto>("tr");
            var fakeResponse = new RepoResponse<TransactionChannelDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<TransactionChannelDto>())).ReturnsAsync(fakeResponse);
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