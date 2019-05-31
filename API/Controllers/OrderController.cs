using System.Linq;
using System.Security.Claims;
using Application.DTO;
using Application.Searches;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderService _service;
        
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            search.UserId = userId;
            
            var orders = _service.Execute(search);
            
            if (orders == null)
            {
                return Ok("You don't have any orders yet!");
            }
            return Ok(orders);
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}