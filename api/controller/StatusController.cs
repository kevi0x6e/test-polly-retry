using domain.Application;
using Microsoft.AspNetCore.Mvc;

namespace api.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IGetStatusCodeService _getStatusCodeService;

        public StatusController(IGetStatusCodeService getStatusCodeService)
        {
            _getStatusCodeService = getStatusCodeService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetStatusAsync()
        {
            var statusCode = await _getStatusCodeService.GetStatusCodeAsync();
            return Ok(statusCode);
        }
    }
}
