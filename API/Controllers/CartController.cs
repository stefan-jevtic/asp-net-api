using System;
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
    public class CartController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var items = _unitOfWork.Cart.GetAll().Where(c => c.UserId == userId).Select(c => new { c.Id, c.Dish.Title, c.Quantity, c.Dish.Price, c.Sum });
            if (!items.ToList().Any())
            {
                return Ok("Your cart is empty!");
            }
            return Ok(items);
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

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            Console.WriteLine(userId);
            var items = _unitOfWork.Cart.GetAll().Where(c => c.UserId == userId).Select(c => new { c.Id, c.Dish.Title, c.Quantity, c.Dish.Price, c.Sum }).ToList();
            var overall = 0.0;
            var desc = "Your order: \n";
            if (!items.Any())
            {
                return Ok("Your cart is empty!");
            }
            foreach (var item in items)
            {
                overall += item.Sum;
                desc += item.Title + ", " + item.Price + " RSD x " + item.Quantity + " = " + item.Sum + " RSD\n";
            }

            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == userId).FirstOrDefault();
            
            if (wallet != null && wallet.Balance < overall)
            {
                return Ok("You don't have enough money to pay! Please refill your account!");
            }

            foreach (var item in items)
            {
                _unitOfWork.Cart.DeleteFromCart(userId, item.Id);
            }
            
            _unitOfWork.Order.InsertOrder(userId, desc, overall);
            wallet.Balance -= overall;
            _unitOfWork.Transaction.CreateTransaction(wallet.Id, overall, "Output");
            _unitOfWork.Save();

            return Ok("Your order successfully purchased!");
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