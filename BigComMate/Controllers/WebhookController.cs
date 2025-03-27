using BigComMate.Entity.Common.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BigComMate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebhookController : ControllerBase
{
    [HttpPost("uninstall")]
    public IActionResult Uninstall([FromBody] UninstallPayload payload)
    {
        // Remove store data from DB
        return Ok();
    }
}
