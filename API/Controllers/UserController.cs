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
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Transactions")]
        public IActionResult Transactions()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == userId).FirstOrDefault();
            var transactions = _unitOfWork.Transaction.Find(t => t.WalletId == wallet.Id).Select(t => new TransactionDTO()
            {
                Id = t.Id,
                Amount = t.Amount,
                Type = t.Type,
                CreatedAt = t.CreatedAt
            });
            return Ok(transactions);
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            var userId = AuthMiddleware.GetUserId(this.GetClaim());
            return Ok(userId);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] AuthDTO dto)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            _unitOfWork.User.UpdateUser(dto, userId);
            _unitOfWork.Save();
            return Ok("Successfully updated!");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            _unitOfWork.User.SoftRemove(userId);
            _unitOfWork.Save();
            return Ok("Your account is successfully deleted!");
        }

        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}