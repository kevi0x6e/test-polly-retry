using domain.Application;
using domain.Infrastructure;

namespace application.GetStatusCodeService;

public class GetStatusCodeService : IGetStatusCodeService
{
    private readonly ILocalExternalService _localExternalService;

    public GetStatusCodeService(ILocalExternalService localExternalService)
        => _localExternalService = localExternalService;

    public async Task<bool> GetStatusCodeAsync()
        => await _localExternalService.GetStatusCodeAsync();
}
