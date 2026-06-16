using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.DBContext.Modules;

namespace WebApplication2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly AppDBContext _context;
        readonly IConfiguration _configuration;
        public LoginController(AppDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [NonAction]
        public string CreateJWTToken( Users users)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, users.FullName),
                new Claim(ClaimTypes.Name, users.Email),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var toekn = new JwtSecurityToken(
                issuer: _configuration.GetSection("jwt:Issuer").Value,
                audience: _configuration.GetSection("jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(toekn);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (loginDto.Email == null && loginDto.Password == null) 
                {
                  return BadRequest();  
                }
                var User = await _context.Users.SingleOrDefaultAsync(m => m.Email == loginDto.Email);
                if (User == null)
                {
                    return  BadRequest("Email or password is incorrect");
                }
                bool isCorrect = BCrypt.Net.BCrypt.Verify(loginDto.Password, User.Password);
                if (!isCorrect)
                {
                    return BadRequest("Email or password is incorrect");
                }

                var token =CreateJWTToken(User);
                
                
                return Ok(new {token =token,Username =User.FullName});
            }
    }
}
