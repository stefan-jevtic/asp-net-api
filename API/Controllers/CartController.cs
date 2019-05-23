using System;
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
    public class CartController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CartDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            if (dto.Quantity < 1)
            {
                return BadRequest("Please insert positive number for quantity!");
            }
            if (dto.DishId < 1)
            {
                return BadRequest("Please insert positive number for dish!");
            }
            var dish = _unitOfWork.Dish.Get(dto.DishId);
            if (dish == null)
            {
                return BadRequest("Dish not found! Please check our dish list then choose correct dish id!");
            }
            _unitOfWork.Cart.InsertInCart(userId, dto.DishId, dto.Quantity, dto.Quantity * dish.Price);
            _unitOfWork.Save();
            return Ok(dish.Title + " successfully added to cart!");
        }

        public IActionResult Delete([FromBody] CartDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var status = _unitOfWork.Cart.DeleteFromCart(userId, dto.Id);
            _unitOfWork.Save();
            return Ok(status == 1 ? "Successfully removed from cart!" : "Wrong cart item number!");
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}