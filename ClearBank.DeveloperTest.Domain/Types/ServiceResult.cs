namespace ClearBank.DeveloperTest.Domain.Types
{
    public class ServiceResult<T> : BaseServiceResult
    {
        public T? Result { get; set; }
    }
}
