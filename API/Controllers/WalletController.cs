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
    public class WalletController : Controller
    {
        private IWalletService _service;
        public WalletController(IWalletService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var wallet = _service.GetById(userId);
            return Ok("Your balance is: " + wallet.Amount);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WalletDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            try
            {
                var balance = _service.InsertMoney(dto, userId);
                return Ok("Your current balance is: " + balance);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}