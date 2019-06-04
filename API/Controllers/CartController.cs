using System;
using System.Security.Claims;
using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var userId = AuthMiddleware.GetUserId(User);
            try
            {
                var items = _service.ListCart(userId);
                return Ok(items);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CartDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(User);
            dto.UserId = userId;
            try
            {
                _service.Insert(dto);
                return Ok("Successfully added to cart!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] CartDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(User);
            try
            {
                if (_service.CheckItemExist(userId, dto.Id))
                {
                    _service.Update(dto, dto.Id);
                    return Ok("Quantity successfully updated!");
                }
                return BadRequest("Order with that id does not exist in your cart!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit()
        {
            var userId = AuthMiddleware.GetUserId(User);
            try
            {
                _service.Purchase(userId);
                return Ok("Your order successfully purchased!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] CartDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(User);
            if (_service.CheckItemExist(userId, dto.Id))
            {
                _service.DeleteById(dto.Id);
                return Ok("Successfully deleted!");
            }

            return BadRequest("Order with that id does not exist in your cart!");
        }
    }
}