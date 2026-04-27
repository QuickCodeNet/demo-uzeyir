using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.TransactionFee;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.TransactionFee;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Tests.Services.TransactionFee
{
    public class TransactionFeeServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ITransactionFeeRepository> _repositoryMock;
        private readonly Mock<ILogger<TransactionFeeService>> _loggerMock;
        private readonly TransactionFeeService _service;
        public TransactionFeeServiceDeleteTests()
        {
            _repositoryMock = new Mock<ITransactionFeeRepository>();
            _loggerMock = new Mock<ILogger<TransactionFeeService>>();
            _service = new TransactionFeeService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TransactionFeeDto>("tr");
            var fakeGetResponse = new RepoResponse<TransactionFeeDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<TransactionFeeDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<TransactionFeeDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<TransactionFeeDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<TransactionFeeDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<TransactionFeeDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}