using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.CollateralType;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.CollateralType;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Tests.Services.CollateralType
{
    public class InsertCollateralTypeCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ICollateralTypeRepository> _repositoryMock;
        private readonly Mock<ILogger<CollateralTypeService>> _loggerMock;
        private readonly CollateralTypeService _service;
        public InsertCollateralTypeCommandTests()
        {
            _repositoryMock = new Mock<ICollateralTypeRepository>();
            _loggerMock = new Mock<ILogger<CollateralTypeService>>();
            _service = new CollateralTypeService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CollateralTypeDto>("tr");
            var fakeResponse = new RepoResponse<CollateralTypeDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CollateralTypeDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<CollateralTypeDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CollateralTypeDto>("tr");
            var fakeResponse = new RepoResponse<CollateralTypeDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CollateralTypeDto>())).ReturnsAsync(fakeResponse);
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