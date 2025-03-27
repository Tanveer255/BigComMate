using BigComMate.Entity.Common.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BigComMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("callback")]
        public async Task<IActionResult> AuthCallback([FromQuery] string code, [FromQuery] string context)
        {
            using var client = new HttpClient();
            var requestData = new
            {
                client_id = "YOUR_CLIENT_ID",
                client_secret = "YOUR_CLIENT_SECRET",
                code,
                grant_type = "authorization_code",
                redirect_uri = "YOUR_REDIRECT_URI",
                context
            };

            var response = await client.PostAsJsonAsync("https://login.bigcommerce.com/oauth2/token", requestData);
            var tokenData = await response.Content.ReadFromJsonAsync<OAuthResponse>();

            // Save the store hash and access token in the database
            return Ok(new { message = "App Installed Successfully" });
        }
    }
}
