namespace domain.Application;

public interface IGetStatusCodeService
{
    Task<bool> GetStatusCodeAsync();
}
