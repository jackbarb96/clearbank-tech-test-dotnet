using ClearBank.DeveloperTest.Domain.Enums;
using ClearBank.DeveloperTest.Domain.Types;
using ClearBank.DeveloperTest.Repository.Interfaces;

namespace ClearBank.DeveloperTest.Repository.Factories
{
    public interface IAccountDataStoreFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IAccountDataStore"/> based on the provided <see cref="DataStoreType"/>.
        /// </summary>
        /// <param name="dataStoreType">The data store type.</param>
        /// <returns>A <see cref="ServiceResult<IAccountDataStore>"/>, denoting success or failure, containing a data store instance. <</returns>
        ServiceResult<IAccountDataStore> Create(DataStoreType dataStoreType);
    }
}
