using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Domain.Enums;
using ClearBank.DeveloperTest.Domain.Types;
using ClearBank.DeveloperTest.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests.Services.AccountServiceTests
{
    [TestClass]
    public class UpdateAccountTests : TestBase
    {
        [TestMethod]
        public void ShouldReturnSuccess_WhenAccountUpdatedSuccessfully()
        {
            // Arrange
            var mockAccount = new Account
            {
                AccountNumber = "12345678",
                Balance = 1000,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs | AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Live
            };

            var mockAccountDataStoreResult = new ServiceResult<IAccountDataStore> { Success = true, Result = new AccountDataStore() };

            mockAccountDataStoreFactory.Setup(x => x.Create(It.IsAny<DataStoreType>())).Returns(mockAccountDataStoreResult);

            // Act
            var result = accountService.UpdateAccount(mockAccount);

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}
