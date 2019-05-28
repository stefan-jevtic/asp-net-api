using System.Linq;
using System.Security.Claims;
using Application.DTO;
using Application.Searches;
using Application.Services;
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
        private IUnitOfWork _unitOfWork;
        
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            search.UserId = userId;
            
            var orders = _unitOfWork.Order.Execute(search);
            
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