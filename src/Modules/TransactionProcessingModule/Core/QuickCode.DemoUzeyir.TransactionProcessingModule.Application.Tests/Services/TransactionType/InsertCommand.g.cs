using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.TransactionType;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.TransactionType;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Tests.Services.TransactionType
{
    public class InsertTransactionTypeCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ITransactionTypeRepository> _repositoryMock;
        private readonly Mock<ILogger<TransactionTypeService>> _loggerMock;
        private readonly TransactionTypeService _service;
        public InsertTransactionTypeCommandTests()
        {
            _repositoryMock = new Mock<ITransactionTypeRepository>();
            _loggerMock = new Mock<ILogger<TransactionTypeService>>();
            _service = new TransactionTypeService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TransactionTypeDto>("tr");
            var fakeResponse = new RepoResponse<TransactionTypeDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<TransactionTypeDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<TransactionTypeDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TransactionTypeDto>("tr");
            var fakeResponse = new RepoResponse<TransactionTypeDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<TransactionTypeDto>())).ReturnsAsync(fakeResponse);
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