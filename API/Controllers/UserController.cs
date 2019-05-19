using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        // GET
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] object data)
        {
            return Ok(data);
        }
    }
}