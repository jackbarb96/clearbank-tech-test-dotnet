using ClearBank.DeveloperTest.Domain.Enums;
using ClearBank.DeveloperTest.Domain.Types;

namespace ClearBank.DeveloperTest.Repository.Interfaces
{
    public interface IAccountDataStore
    {
        /// <summary>
        /// The data store type this instance represents.
        /// </summary>
        DataStoreType DataStoreType { get; }

        /// <summary>
        /// Gets the account by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>A <see cref="Account"/> instance.</returns>
        public Account GetAccount(string accountNumber);

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        public void UpdateAccount(Account account);
    }
}
