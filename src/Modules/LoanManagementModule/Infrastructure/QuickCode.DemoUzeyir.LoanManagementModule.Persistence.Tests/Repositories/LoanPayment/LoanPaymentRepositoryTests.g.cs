using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Repositories;
using QuickCode.DemoUzeyir.Common.Data;
using Xunit.Abstractions;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Tests.Repositories
{
    public class LoanPaymentRepositoryTests : IDisposable
    {
        private readonly Mock<IDbConnectionFactory> connectionFactoryMock;
        private readonly Mock<ILogger<LoanPaymentRepository>> loggerMock;
        private readonly ITestOutputHelper _output;
        public LoanPaymentRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
            connectionFactoryMock = new Mock<IDbConnectionFactory>();
            loggerMock = new Mock<ILogger<LoanPaymentRepository>>();
        }

        private LoanPaymentRepository CreateRepository()
        {
            return new LoanPaymentRepository(loggerMock.Object, connectionFactoryMock.Object);
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