using HotelBookings.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBookingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSystemController : ControllerBase
    {
        [HttpPost]

        public IActionResult Login([FromBody] LoginSystem login)
        {
            if (login.Login == "admin" && login.Password == "admin")
            {
                var token = GerarTokenJwt();
                return Ok(new { token });
            }
            return BadRequest("Credenciais inválidas. Por favor, verifique seu nome de usuário e senha!");
        }

        private string GerarTokenJwt()
        {
            string chaveSecreta = "ae452bfe-50c2-4291-bcf9-a63d96838ed9";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("nome", "System Administrator")
            };

            var token = new JwtSecurityToken(
                issuer: "HotelBookings",
                audience: "HotelBookings",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
