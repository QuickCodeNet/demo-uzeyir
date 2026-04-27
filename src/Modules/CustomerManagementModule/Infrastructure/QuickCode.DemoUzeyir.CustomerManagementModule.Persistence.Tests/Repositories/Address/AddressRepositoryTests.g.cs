using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Repositories;
using QuickCode.DemoUzeyir.Common.Data;
using Xunit.Abstractions;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Tests.Repositories
{
    public class AddressRepositoryTests : IDisposable
    {
        private readonly Mock<IDbConnectionFactory> connectionFactoryMock;
        private readonly Mock<ILogger<AddressRepository>> loggerMock;
        private readonly ITestOutputHelper _output;
        public AddressRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
            connectionFactoryMock = new Mock<IDbConnectionFactory>();
            loggerMock = new Mock<ILogger<AddressRepository>>();
        }

        private AddressRepository CreateRepository()
        {
            return new AddressRepository(loggerMock.Object, connectionFactoryMock.Object);
        }

        [Fact]
        public void Constructor_Should_Create_Repository_With_Connection_Factory()
        {
            var repository = CreateRepository();
            Assert.NotNull(repository);
        }

        public void Dispose()
        {
            _output.WriteLine("Repository tests use IDbConnectionFactory. Provider-specific integration coverage belongs in relational DB test fixtures.");
        }
    }
}