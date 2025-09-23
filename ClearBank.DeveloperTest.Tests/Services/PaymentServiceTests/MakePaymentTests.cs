using ClearBank.DeveloperTest.Domain.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Services.PaymentServiceTests
{
    [TestClass]
    public class MakePaymentTests : TestBase
    {
        [TestMethod]
        [DataRow(PaymentScheme.Bacs)]
        [DataRow(PaymentScheme.FasterPayments)]
        [DataRow(PaymentScheme.Chaps)]
        public void ShouldReturnSuccess_WhenPaymentIsValid(PaymentScheme paymentScheme)
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                Amount = 100,
                DebtorAccountNumber = "12345678",
                PaymentScheme = paymentScheme
            };

            var mockAccount = new Account
            {
                AccountNumber = "12345678",
                Balance = 500,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs | AllowedPaymentSchemes.Chaps | AllowedPaymentSchemes.FasterPayments,
                Status = AccountStatus.Live
            };

            mockAccountService.Setup(x => x.GetAccount("12345678")).Returns(new ServiceResult { Success = true, Result = mockAccount });

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        [DataRow(PaymentScheme.FasterPayments, AllowedPaymentSchemes.Chaps | AllowedPaymentSchemes.Bacs)]
        [DataRow(PaymentScheme.Bacs, AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Chaps)]
        [DataRow(PaymentScheme.Chaps, AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Bacs)]
        public void ShouldReturnFailure_WhenPaymentSchemeNotAllowed(PaymentScheme paymentScheme, AllowedPaymentSchemes allowedPaymentSchemes)
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                Amount = 100,
                DebtorAccountNumber = "12345678",
                PaymentScheme = paymentScheme
            };

            var mockAccount = new Account
            {
                AccountNumber = "12345678",
                Balance = 500,
                AllowedPaymentSchemes = allowedPaymentSchemes,
                Status = AccountStatus.Live
            };

            mockAccountService.Setup(x => x.GetAccount("12345678")).Returns(new ServiceResult { Success = true, Result = mockAccount });

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void ShouldReturnFailure_WhenInsufficientFunds_ForFasterPayments()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                Amount = 10000,
                DebtorAccountNumber = "12345678",
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var mockAccount = new Account
            {
                AccountNumber = "12345678",
                Balance = 500,
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Status = AccountStatus.Live
            };

            mockAccountService.Setup(x => x.GetAccount("12345678")).Returns(new ServiceResult { Success = true, Result = mockAccount });

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        [DataRow(PaymentScheme.Bacs)]
        [DataRow(PaymentScheme.FasterPayments)]
        [DataRow(PaymentScheme.Chaps)]
        public void ShouldReturnFailure_WhenAccountIsNull(PaymentScheme paymentScheme)
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                Amount = 100,
                DebtorAccountNumber = "12345678",
                PaymentScheme = paymentScheme
            };

            mockAccountService.Setup(x => x.GetAccount("12345678")).Returns(new ServiceResult { Success = false });

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void ShouldReturnFailure_WhenAccountStatusNotLive_ForChaps()
        {
            // Arrange
            var request = new MakePaymentRequest
            {
                Amount = 100,
                DebtorAccountNumber = "12345678",
                PaymentScheme = PaymentScheme.Chaps
            };

            var mockAccount = new Account
            {
                AccountNumber = "12345678",
                Balance = 500,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Disabled
            };

            mockAccountService.Setup(x => x.GetAccount("12345678")).Returns(new ServiceResult { Success = true, Result = mockAccount });

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
        }
    }
}
