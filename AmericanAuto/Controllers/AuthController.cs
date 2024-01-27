using AmericanAuto.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AmericanAuto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AdminSettings _adminSettings;
        private readonly AuthenticationConfig _authenticationConfig;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IOptions<AdminSettings> adminSettings, IOptions<AuthenticationConfig> authenticationConfig, ILogger<AuthController> logger)
        {
            _adminSettings = adminSettings.Value;
            _authenticationConfig = authenticationConfig.Value;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminSettings payload)
        {
            if (!ModelState.IsValid || payload == null)
            {
                return BadRequest(payload);
            }

            if (payload.Username == _adminSettings.Username && payload.Password == _adminSettings.Password)
            {
                // Create a list of claims
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, payload.Username)
                // Add more claims if needed
                };

                // Generate a security key from the secret key
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfig.Key)); // Replace with your real secret key

                // Generate a signing credentials
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // Create the token
                var token = new JwtSecurityToken(
                    // You can include the issuer and audience here if needed
                    claims: claims,
                    expires: DateTime.Now.AddYears(10),
                    signingCredentials: credentials);

                // Write the token to the response
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest(payload);
        }
    }
}