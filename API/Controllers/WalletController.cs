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
    public class WalletController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public WalletController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == userId).FirstOrDefault();
            return Ok("Your balance is: " + wallet.Balance);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WalletDTO dto)
        {
            if (Double.IsNaN(dto.Amount) || dto.Amount < 1)
            {
                return BadRequest("Please insert number positive number greater then 1!");
            }
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var balance = _unitOfWork.Wallet.InsertMoney(dto.Amount, userId);
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == userId).FirstOrDefault();
            _unitOfWork.Transaction.CreateTransaction(wallet.Id, dto.Amount, "Input");
            _unitOfWork.Save();
            return Ok("Your current balance is: " + balance);
        }
        
        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}