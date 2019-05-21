using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var user = _unitOfWork.User.Get(userId);
            Console.WriteLine(user);
            if (!String.IsNullOrEmpty(dto.Email))
            {
                user.Email = dto.Email;
            }
            if (!String.IsNullOrEmpty(dto.FirstName))
            {
                user.FirstName = dto.FirstName;
            }
            if (!String.IsNullOrEmpty(dto.LastName))
            {
                user.LastName = dto.LastName;
            }
            if (!String.IsNullOrEmpty(dto.Password))
            {
                user.Password = dto.Password;
            }
            
            _unitOfWork.Save();
            
            return Ok("Successfully updated!");
        }

        ClaimsIdentity GetClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}