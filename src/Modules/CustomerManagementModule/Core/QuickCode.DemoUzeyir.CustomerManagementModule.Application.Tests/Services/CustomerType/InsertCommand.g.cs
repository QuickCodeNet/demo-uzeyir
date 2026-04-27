using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.CustomerType;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.CustomerType;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Tests.Services.CustomerType
{
    public class InsertCustomerTypeCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ICustomerTypeRepository> _repositoryMock;
        private readonly Mock<ILogger<CustomerTypeService>> _loggerMock;
        private readonly CustomerTypeService _service;
        public InsertCustomerTypeCommandTests()
        {
            _repositoryMock = new Mock<ICustomerTypeRepository>();
            _loggerMock = new Mock<ILogger<CustomerTypeService>>();
            _service = new CustomerTypeService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CustomerTypeDto>("tr");
            var fakeResponse = new RepoResponse<CustomerTypeDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CustomerTypeDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<CustomerTypeDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CustomerTypeDto>("tr");
            var fakeResponse = new RepoResponse<CustomerTypeDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CustomerTypeDto>())).ReturnsAsync(fakeResponse);
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