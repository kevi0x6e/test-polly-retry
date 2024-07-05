namespace domain.Infrastructure;

public interface ILocalExternalService
{
    Task<bool> GetStatusCodeAsync();
}
