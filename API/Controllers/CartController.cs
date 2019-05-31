using System;
using System.Linq;
using System.Security.Claims;
using Application.DTO;
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
    public class CartController : Controller
    {
        private ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var items = _service.ListCart(userId);
            return Ok(items);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CartDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            dto.UserId = userId;
            _service.Insert(dto);
            return Ok("Successfully added to cart!");
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            _service.Purchase(userId);
            return Ok("Your order successfully purchased!");
        }

        public IActionResult Delete([FromBody] CartDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            // todo: Proveriti da li je korisnik prosledio svoju prodzbinu!
            _service.DeleteById(dto.Id);
            return Ok("Successfully deleted!");
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}