using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountHolder;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountHolder;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Tests.Services.AccountHolder
{
    public class UpdateAccountHolderCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IAccountHolderRepository> _repositoryMock;
        private readonly Mock<ILogger<AccountHolderService>> _loggerMock;
        private readonly AccountHolderService _service;
        public UpdateAccountHolderCommandTests()
        {
            _repositoryMock = new Mock<IAccountHolderRepository>();
            _loggerMock = new Mock<ILogger<AccountHolderService>>();
            _service = new AccountHolderService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AccountHolderDto>("tr");
            var fakeGetResponse = new RepoResponse<AccountHolderDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.AccountId, fakeDto.CustomerId)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<AccountHolderDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.AccountId, fakeDto.CustomerId, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.AccountId, fakeDto.CustomerId), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<AccountHolderDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AccountHolderDto>("tr");
            var fakeGetResponse = new RepoResponse<AccountHolderDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.AccountId, fakeDto.CustomerId)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.AccountId, fakeDto.CustomerId, fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.AccountId, fakeDto.CustomerId), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<AccountHolderDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}