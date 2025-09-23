using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Domain.Types;
using Microsoft.Extensions.Configuration;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private static string _dataStoreType;

        public AccountService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            _dataStoreType = _configuration.GetSection("DataStoreType").Value;
        }

        public ServiceResult GetAccount(string accountNumber)
        {
            var account = new Account();

            if (_dataStoreType == "Backup")
            {
                var accountDataStore = new BackupAccountDataStore();
                account = accountDataStore.GetAccount(accountNumber);
            }
            else
            {
                var accountDataStore = new AccountDataStore();
                account = accountDataStore.GetAccount(accountNumber);
            }

            return new ServiceResult { Success = true, Result = account };
        }

        public ServiceResult UpdateAccount(Account account)
        {
            if (_dataStoreType == "Backup")
            {
                var accountDataStore = new BackupAccountDataStore();
                accountDataStore.UpdateAccount(account);
            }
            else
            {
                var accountDataStore = new AccountDataStore();
                accountDataStore.UpdateAccount(account);
            }

            return new ServiceResult { Success = true };
        }
    }
}
