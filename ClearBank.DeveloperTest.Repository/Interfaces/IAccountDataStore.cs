using ClearBank.DeveloperTest.Domain.Types;

namespace ClearBank.DeveloperTest.Repository.Interfaces
{
    public interface IAccountDataStore
    {
        /// <summary>
        /// Gets the account by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>A <see cref="ServiceResult"/> denoting success or failure, containing the account.</returns>
        public Account GetAccount(string accountNumber);

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>A <see cref="ServiceResult"/> denoting success or failure.</returns>
        public void UpdateAccount(Account account);
    }
}
