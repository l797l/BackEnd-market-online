using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DBContext.Modules;

namespace WebApplication2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        readonly AppDBContext context;
        public RegisterController(AppDBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> registerAccount(RegisterDto registerDto)
        {
            if (registerDto == null || registerDto.FullName == null || registerDto.Email == null ||
                registerDto.Password == null)
            {
                return  BadRequest();
            }
            var User = context.Users.FirstOrDefault(x => x.Email == registerDto.Email);

            if (User != null)
            {
                return BadRequest("is Email already in use");
            }
            var passwordCrypt = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            var newUser = new Users()
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                Password = passwordCrypt
            };
            context.Users.Add(newUser);
            context.SaveChanges();
            return Ok();
        }
    }
}
