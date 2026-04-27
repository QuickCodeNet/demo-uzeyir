using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Repositories;
using QuickCode.DemoUzeyir.Common.Data;
using Xunit.Abstractions;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Tests.Repositories
{
    public class CardTypeRepositoryTests : IDisposable
    {
        private readonly Mock<IDbConnectionFactory> connectionFactoryMock;
        private readonly Mock<ILogger<CardTypeRepository>> loggerMock;
        private readonly ITestOutputHelper _output;
        public CardTypeRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
            connectionFactoryMock = new Mock<IDbConnectionFactory>();
            loggerMock = new Mock<ILogger<CardTypeRepository>>();
        }

        private CardTypeRepository CreateRepository()
        {
            return new CardTypeRepository(loggerMock.Object, connectionFactoryMock.Object);
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