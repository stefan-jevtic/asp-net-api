using System;
using System.Linq;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        private AuthMiddleware _middleware;
        
        public AuthController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _middleware = new AuthMiddleware(_config);
        }
        
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] AuthDTO data)
        {
            if (String.IsNullOrEmpty(data.FirstName))
            {
                return BadRequest("First name field is required!");
            }
            
            if (String.IsNullOrEmpty(data.LastName))
            {
                return BadRequest("Last name field is required!");
            }
            
            if (String.IsNullOrEmpty(data.Email))
            {
                return BadRequest("Email field is required!");
            }
            
            if (String.IsNullOrEmpty(data.Password))
            {
                return BadRequest("Password field is required!");
            }

            if (!data.Email.Contains("@"))
            {
                return BadRequest("Enter valid email!");
            }

            data.Password = _middleware.ComputeSha256Hash(data.Password);
            
            
            _unitOfWork.User.RegisterUser(data);
            _unitOfWork.Save();
            
            return Ok("User successfully registered!");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthDTO data)
        {
            var token = "No token!";
            
            if (String.IsNullOrEmpty(data.Email))
            {
                return BadRequest("Email field is required!");
            }
            
            if (String.IsNullOrEmpty(data.Password))
            {
                return BadRequest("Password field is required!");
            }
            
            if (!data.Email.Contains("@"))
            {
                return BadRequest("Enter valid email!");
            }

            var pass = _middleware.ComputeSha256Hash(data.Password);
            var user = _unitOfWork.User.Find(u => u.Email == data.Email && u.Password == pass);
            
            if (user.Count() == 1)
            {
                token = _middleware.GenerateJsonWebToken(user);
                return Ok(token);
            }

            return BadRequest("User not found!");
            
        }
    }
}