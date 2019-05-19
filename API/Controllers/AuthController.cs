using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.DTO;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Repositories;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        
        public AuthController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
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

            data.Password = ComputeSha256Hash(data.Password);
            
            
            _unitOfWork.User.RegisterUser(data);
            _unitOfWork.Save();
            
            return Ok("User successfully registried!");
        }

        [Authorize]
        [HttpGet]
        [Route("Zasticena")]
        public IActionResult Zasticena()
        {
            return Ok("Proso si");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthDTO data)
        {
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
            
            

            var token = GenerateJSONWebToken(data);
            
            return Ok(token);
        }
        
        static string ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }  
        private string GenerateJSONWebToken(AuthDTO dto)  
        {  
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));  
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);  
            
            var claims = new[] {  
                new Claim(JwtRegisteredClaimNames.Email, dto.Email),  
                new Claim(JwtRegisteredClaimNames.Sid, dto.Password)
            }; 
  
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],  
                _config["Jwt:Issuer"],  
                null,  
                expires: DateTime.Now.AddMinutes(120),  
                signingCredentials: credentials);  
  
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }  
    }
}