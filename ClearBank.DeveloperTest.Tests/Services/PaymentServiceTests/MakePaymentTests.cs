using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Services.PaymentServiceTests
{
    [TestClass]
    public class MakePaymentTests : TestBase
    {
        //TODO: Untestable, need to able to mock account details, will fail on AllowedPaymentSchemes check
        [TestMethod]
        [Ignore]
        [DataRow(PaymentScheme.Bacs)]
        [DataRow(PaymentScheme.FasterPayments)]
        [DataRow(PaymentScheme.Chaps)]
        public void ShouldReturnSuccess_WhenPaymentIsValid(PaymentScheme paymentScheme)
        {
            // Arrange
            Initialise();
            var request = new MakePaymentRequest
            {
                Amount = 100,
                DebtorAccountNumber = "12345678",
                PaymentScheme = paymentScheme
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsTrue(result.Success);
        }

        //TODO: Untestable, need to able to mock account details
        [TestMethod]
        [Ignore]
        [DataRow(PaymentScheme.FasterPayments, AllowedPaymentSchemes.Chaps | AllowedPaymentSchemes.Bacs)]
        [DataRow(PaymentScheme.Bacs, AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Chaps)]
        [DataRow(PaymentScheme.Chaps, AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Bacs)]
        public void ShouldReturnFailure_WhenPaymentSchemeNotAllowed(PaymentScheme paymentScheme, AllowedPaymentSchemes allowedPaymentSchemes)
        {
            // Arrange
            Initialise();
            var request = new MakePaymentRequest
            {
                Amount = 100,
                DebtorAccountNumber = "12345678",
                PaymentScheme = PaymentScheme.Bacs
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
        }

        //TODO: Untestable, need to able to mock account details
        [TestMethod]
        [Ignore]
        public void ShouldReturnFailure_WhenInsufficientFunds_ForFasterPayments()
        {
            // Arrange
            Initialise();
            var request = new MakePaymentRequest
            {
                Amount = 10000,
                DebtorAccountNumber = "12345678",
                PaymentScheme = PaymentScheme.FasterPayments
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsFalse(result.Success);
        }

        // TODO: Untestable, need to able to mock account details
        [TestMethod]
        [Ignore]
        public void ShouldReturnFailure_WhenAccountDoesNotExist()
        {
            // Arrange
            Initialise();
            var request = new MakePaymentRequest
            {
                Amount = 100,
                DebtorAccountNumber = "00000000",
                PaymentScheme = PaymentScheme.Bacs
            };
            // Act
            var result = paymentService.MakePayment(request);
            // Assert
            Assert.IsFalse(result.Success);
        }
    }
}
