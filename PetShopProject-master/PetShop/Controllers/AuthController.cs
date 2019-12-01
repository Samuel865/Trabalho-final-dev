using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthServices _services;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthServices services, IConfiguration configuration )
        {
            _services = services;
            _configuration = configuration;            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            user.Username = user.Username.ToUpper();

            if(await _services.UserExists(user.Username))
                return BadRequest("Nome de usuário já existe");
            else
                await _services.Register(user, user.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]  
        public async Task<IActionResult> Login(User user)
        {
            var userLogin = await _services.Login(user.Username.ToUpper(), user.Password);
            if(user == null)
            {
                return Unauthorized();
            }
            else
            {
                var claims = new [] {
                    new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
                    new Claim (ClaimTypes.Name, user.Username)
                };
                var key = new SymmetricSecurityKey (Encoding.UTF8
                    .GetBytes (_configuration.GetSection ("AppSettings:Token").Value));

                var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity (claims),
                    Expires = DateTime.Now.AddDays (1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler ();

                var token = tokenHandler.CreateToken (tokenDescriptor);

                return Ok (new {
                    token = tokenHandler.WriteToken (token)
                });
            }
        }      
    }
}