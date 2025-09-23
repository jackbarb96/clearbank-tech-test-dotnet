using ClearBank.DeveloperTest.Domain.Types;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountService;

        public PaymentService(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var accountResult = _accountService.GetAccount(request.DebtorAccountNumber);

            if (!accountResult.Success)
            {
                return new MakePaymentResult { Success = false };
            }

            var account = accountResult.Result as Account;

            var result = new MakePaymentResult();

            result.Success = IsPaymentPossible(request, account);

            if (result.Success)
            {
                account.Balance -= request.Amount;

                _accountService.UpdateAccount(account);
            }

            return result;
        }

        private static bool IsPaymentPossible(MakePaymentRequest request, Account account)
        {
            var result = true;

            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                    {
                        result = false;
                    }
                    break;

                case PaymentScheme.FasterPayments:
                    if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                    {
                        result = false;
                    }
                    else if (account.Balance < request.Amount)
                    {
                        result = false;
                    }
                    break;

                case PaymentScheme.Chaps:
                    if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
                    {
                        result = false;
                    }
                    else if (account.Status != AccountStatus.Live)
                    {
                        result = false;
                    }
                    break;
            }

            return result;
        }
    }
}
