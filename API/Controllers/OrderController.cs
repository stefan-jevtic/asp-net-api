using System.Linq;
using System.Security.Claims;
using Application.DTO;
using Application.Responses;
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
        public ActionResult<PageResponse<OrderDTO>> Get([FromQuery] OrderSearch search)
        {
            var userId = AuthMiddleware.GetUserId(User);
            search.UserId = userId;
            
            var orders = _service.Execute(search);
            
            if (orders == null)
            {
                return Ok("You don't have any orders yet!");
            }
            return Ok(orders);
        }
    }
}