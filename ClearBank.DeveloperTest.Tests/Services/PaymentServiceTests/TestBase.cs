using ClearBank.DeveloperTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests.Services.PaymentServiceTests
{
    public class TestBase
    {
        protected Mock<IAccountService> mockAccountService;
        internal PaymentService paymentService;

        [TestInitialize]
        public void Initialise()
        {
            mockAccountService = new Mock<IAccountService>();

            paymentService = new PaymentService(mockAccountService.Object);
        }
    }
}
