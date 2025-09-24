using ClearBank.DeveloperTest.Domain.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Gets the account by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>A <see cref="ServiceResult<Account>"/> denoting success or failure, containing the account.</returns>
        ServiceResult<Account> GetAccount(string accountNumber);

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>A <see cref="BaseServiceResult"/> denoting success or failure.</returns>
        BaseServiceResult UpdateAccount(Account account);
    }
}
