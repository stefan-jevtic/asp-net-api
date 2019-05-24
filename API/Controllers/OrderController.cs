using System.Linq;
using System.Security.Claims;
using Application.DTO;
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
        public IActionResult Get()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var orders = _unitOfWork.Order.GetAll().Select(o => new OrderDTO()
            {
                Id = o.Id,
                CreatedAt = o.CreatedAt,
                Description = o.Description,
                Total = o.Total
            }).ToList();
            if (!orders.Any())
            {
                return Ok("You don't have any order yet!");
            }
            return Ok(orders);
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}