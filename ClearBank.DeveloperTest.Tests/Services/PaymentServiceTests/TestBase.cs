using ClearBank.DeveloperTest.Services;

namespace ClearBank.DeveloperTest.Tests.Services.PaymentServiceTests
{
    public class TestBase
    {
        internal PaymentService paymentService;

        public void Initialise()
        {
            paymentService = new PaymentService();
        }
    }
}
