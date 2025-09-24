using ClearBank.DeveloperTest.Repository.Factories;
using ClearBank.DeveloperTest.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ClearBank.DeveloperTest.Tests.Services.AccountServiceTests
{
    public class TestBase
    {
        protected IConfiguration mockConfiguration;
        protected Mock<IAccountDataStoreFactory> mockAccountDataStoreFactory;
        internal AccountService accountService;

        [TestInitialize]
        public void Initialise()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"DataStoreType", "Primary"},
            };

            mockConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            mockAccountDataStoreFactory = new Mock<IAccountDataStoreFactory>();

            accountService = new AccountService(mockConfiguration, mockAccountDataStoreFactory.Object);
        }
    }
}
