using System.Linq;
using System.Security.Claims;
using Application.DTO;
using Application.Searches;
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
        public IActionResult Transactions([FromQuery] TransactionSearch search)
        {
            var userId = AuthMiddleware.GetUserId(GetClaim());
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == userId).FirstOrDefault();
            search.WalletId = wallet.Id;
            var transactions = _unitOfWork.Transaction.Execute(search);
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