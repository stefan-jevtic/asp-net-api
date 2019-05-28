using System;
using System.Linq;
using System.Security.Claims;
using Application.DTO;
using Application.Searches;
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
        private IUnitOfWork _unitOfWork;

        public DishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] DishSearch search)
        {
            /*var dishes = _unitOfWork.Dish.GetAll().Select(d => new DishDTO()
            {
                Id = d.Id,
                Title = d.Title,
                Ingredients = d.Ingredients,
                Serving = d.Serving,
                Price = d.Price,
                Name = d.Category.Name
            }).OrderBy(d => d.Name).ToList();*/
            var dishes = _unitOfWork.Dish.Execute(search);
            return Ok(dishes);
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}