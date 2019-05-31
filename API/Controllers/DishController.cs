using System;
using System.Linq;
using System.Security.Claims;
using Application.DTO;
using Application.Searches;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DishController : Controller
    {
        private IDishService _service;
        
        public DishController(IDishService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] DishSearch search)
        {
            var dishes = _service.Execute(search);
            return Ok(dishes);
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}