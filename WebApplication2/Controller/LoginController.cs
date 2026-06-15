using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly AppDBContext _context;
        public LoginController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Login()
        {
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
