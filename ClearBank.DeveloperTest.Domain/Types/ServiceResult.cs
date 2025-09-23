namespace ClearBank.DeveloperTest.Domain.Types
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public object? Result { get; set; }
    }
}
