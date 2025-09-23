using ClearBank.DeveloperTest.Domain.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentService
    {
        /// <summary>
        /// Processes a payment request and returns the result of the payment operation.
        /// </summary>
        /// <param name="request">The payment request containing the details of the payment</param>
        /// <returns>A <see cref="MakePaymentResult"/> denoting success or failure.</returns>
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
