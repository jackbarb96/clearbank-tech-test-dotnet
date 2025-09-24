using ClearBank.DeveloperTest.Domain.Enums;
using ClearBank.DeveloperTest.Domain.Types;
using ClearBank.DeveloperTest.Repository.Interfaces;

namespace ClearBank.DeveloperTest.Repository.Factories
{
    public class AccountDataStoreFactory : IAccountDataStoreFactory
    {
        private readonly IEnumerable<IAccountDataStore> _accountDataStores;

        public AccountDataStoreFactory(IEnumerable<IAccountDataStore> accountDataStores)
        {
            _accountDataStores = accountDataStores ?? throw new ArgumentNullException(nameof(accountDataStores));
        }

        public ServiceResult<IAccountDataStore> Create(DataStoreType dataStoreType)
        {
            var accountDataStore = _accountDataStores.FirstOrDefault(x => x.DataStoreType == dataStoreType);

            if (accountDataStore == null)
            {
                return new ServiceResult<IAccountDataStore> { Success = false, ErrorMessage = $"No account data store found for data store type: {dataStoreType}" };
            }

            return new ServiceResult<IAccountDataStore> { Success = true, Result = accountDataStore };
        }
    }
}
