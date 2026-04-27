using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.IdentificationDocument;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.IdentificationDocument;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.Common.Helpers;
using QuickCode.DemoUzeyir.Common.Models;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Tests.Services.IdentificationDocument
{
    public class InsertIdentificationDocumentCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IIdentificationDocumentRepository> _repositoryMock;
        private readonly Mock<ILogger<IdentificationDocumentService>> _loggerMock;
        private readonly IdentificationDocumentService _service;
        public InsertIdentificationDocumentCommandTests()
        {
            _repositoryMock = new Mock<IIdentificationDocumentRepository>();
            _loggerMock = new Mock<ILogger<IdentificationDocumentService>>();
            _service = new IdentificationDocumentService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<IdentificationDocumentDto>("tr");
            var fakeResponse = new RepoResponse<IdentificationDocumentDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<IdentificationDocumentDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<IdentificationDocumentDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<IdentificationDocumentDto>("tr");
            var fakeResponse = new RepoResponse<IdentificationDocumentDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<IdentificationDocumentDto>())).ReturnsAsync(fakeResponse);
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