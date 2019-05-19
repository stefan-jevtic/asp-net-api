using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        // GET
        [Authorize]
        [HttpGet]
        [Route("Test")]
        public IActionResult Register()
        {
            return Ok("Proso si");
        }
    }
}