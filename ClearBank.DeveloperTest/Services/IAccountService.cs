using ClearBank.DeveloperTest.Domain.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Gets the account by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>A <see cref="ServiceResult"/> denoting success or failure, containing the account.</returns>
        ServiceResult GetAccount(string accountNumber);

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>A <see cref="ServiceResult"/> denoting success or failure.</returns>
        ServiceResult UpdateAccount(Account account);
    }
}
