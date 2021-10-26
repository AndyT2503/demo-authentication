using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DI;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAPIService _apiService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAPIService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        [Authorize()]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _apiService.GetInfo();
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult Login()
        {
            var credential = "fThWmZq4t7w!z%C*";
            var key = Encoding.ASCII.GetBytes(credential);
            // Định nghĩa payload cho token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "dc4ecd18-a3dd-4131-848c-27355a1d863a"),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim(ClaimTypes.Name, "abc"),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                //Định nghĩa signature
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            //Tạo token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }
    }
}
