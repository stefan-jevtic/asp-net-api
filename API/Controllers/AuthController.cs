using System;
using System.Security.Cryptography;
using System.Text;
using Application.DTO;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUnitOfWork _unitOfWork;
        
        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}