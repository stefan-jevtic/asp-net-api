using System;
using System.Security.Claims;
using Application.DTO;
using Application.Searches;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Transactions")]
        public IActionResult Transactions([FromQuery] TransactionSearch search)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var transactions = _service.GetTransactions(search, userId);
            return Ok(transactions);
        }

        [HttpPut]
        public IActionResult Put([FromBody] AuthDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            _service.Update(dto, userId);
            return Ok("Successfully updated!");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            _service.DeleteById(userId);
            return Ok("Your account is successfully deleted!");
        }

        [HttpPost]
        [Route("Contact")]
        public IActionResult Contact([FromBody] MailDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            try
            {
                _service.SendMail(dto, userId);
                return Ok("Mail sent!");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong!");
            }
        }

        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}