using BigComMate.Entity.Common.Model;
using BigComMate.Entity.Common.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BigComMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        HttpClient httpClient,
        IOptions<BigCommerceSettings> bigCommerceOptions
        ) : ControllerBase
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly BigCommerceSettings _bigCommerceOptions =bigCommerceOptions.Value;
        [HttpGet("authorize")]
        public IActionResult Authorize()
        {
            var clientId = _bigCommerceOptions.ClientId;
            var redirectUri = _bigCommerceOptions.RedirectUri;
            var authUrl = $"{_bigCommerceOptions.AuthUrl}?client_id={clientId}&response_type=code&scope=store_v2_orders&redirect_uri={redirectUri}";

            return Redirect(authUrl);
        }
        [HttpGet("callback")]
        public async Task<IActionResult> AuthCallback([FromQuery] string code, [FromQuery] string context)
        {
            var requestData = new
            {
                client_id = _bigCommerceOptions.ClientId,
                client_secret = _bigCommerceOptions.ClientSecret,
                code,
                grant_type = "authorization_code",
                redirect_uri = _bigCommerceOptions.RedirectUri,
                context
            };

            var response = await _httpClient.PostAsJsonAsync("https://login.bigcommerce.com/oauth2/token", requestData);
            var tokenData = await response.Content.ReadFromJsonAsync<OAuthResponse>();

            // Save the store hash and access token in the database
            return Ok(new { message = "App Installed Successfully" });
        }

    }
}
