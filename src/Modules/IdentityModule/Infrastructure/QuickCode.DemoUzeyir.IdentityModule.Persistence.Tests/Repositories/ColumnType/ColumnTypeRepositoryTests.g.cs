using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using QuickCode.DemoUzeyir.IdentityModule.Persistence.Repositories;
using QuickCode.DemoUzeyir.Common.Data;
using Xunit.Abstractions;

namespace QuickCode.DemoUzeyir.IdentityModule.Persistence.Tests.Repositories
{
    public class ColumnTypeRepositoryTests : IDisposable
    {
        private readonly Mock<IDbConnectionFactory> connectionFactoryMock;
        private readonly Mock<ILogger<ColumnTypeRepository>> loggerMock;
        private readonly ITestOutputHelper _output;
        public ColumnTypeRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
            connectionFactoryMock = new Mock<IDbConnectionFactory>();
            loggerMock = new Mock<ILogger<ColumnTypeRepository>>();
        }

        private ColumnTypeRepository CreateRepository()
        {
            return new ColumnTypeRepository(loggerMock.Object, connectionFactoryMock.Object);
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