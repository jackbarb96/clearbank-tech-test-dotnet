using ClearBank.DeveloperTest.Domain.Enums;
using ClearBank.DeveloperTest.Domain.Types;
using ClearBank.DeveloperTest.Repository.Factories;
using ClearBank.DeveloperTest.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountDataStoreFactory _accountDataStoreFactory;
        private static string _dataStoreType;

        public AccountService(IConfiguration configuration,
                              IAccountDataStoreFactory accountDataStoreFactory)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _accountDataStoreFactory = accountDataStoreFactory ?? throw new ArgumentNullException(nameof(accountDataStoreFactory));
            _dataStoreType = _configuration.GetSection("DataStoreType").Value;
        }

        public ServiceResult<Account> GetAccount(string accountNumber)
        {
            try
            {
                var dataStore = GetAccountDataStore();

                var account = dataStore.GetAccount(accountNumber);

                return new ServiceResult<Account> { Success = true, Result = account };
            }
            catch(Exception)
            {
                return new ServiceResult<Account> { Success = false, ErrorMessage = "An internal error occured" };
            }
        }

        public BaseServiceResult UpdateAccount(Account account)
        {
            try
            {
                var dataStore = GetAccountDataStore();

                dataStore.UpdateAccount(account);

                return new BaseServiceResult { Success = true };
            }
            catch (Exception)
            {
                return new BaseServiceResult { Success = false, ErrorMessage = "An internal error occured" };
            }
        }

        private IAccountDataStore GetAccountDataStore()
        {
            if (!Enum.TryParse<DataStoreType>(_dataStoreType, true, out var dataStoreType))
            {
                throw new InvalidOperationException("Invalid data store type configured.");
            }

            var dataStore = _accountDataStoreFactory.Create(dataStoreType);

            if (!dataStore.Success)
            {
                throw new InvalidOperationException(dataStore.ErrorMessage);
            }

            return dataStore.Result;
        }
    }
}
