using ClearBank.DeveloperTest.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClearBank.DeveloperTest.Tests.Services.AccountServiceTests
{
    [TestClass]
    public class CtorTests : TestBase
    {
        [TestMethod]
        public void ShouldThrowArgumentNullException_WhenConfigurationIsNull()
        {
            // Act
            Action act = () => new AccountService(null, 
                                                  mockAccountDataStoreFactory.Object);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithParameterName("configuration");
        }

        [TestMethod]
        public void ShouldThrowArgumentNullException_WhenAccountDataStoreFactoryIsNull()
        {
            // Act
            Action act = () => new AccountService(mockConfiguration,
                                                  null);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithParameterName("accountDataStoreFactory");
        }
    }
}
