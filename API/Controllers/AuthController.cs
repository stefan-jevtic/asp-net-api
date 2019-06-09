using System;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUserService _service;
        private IConfiguration _config;
        public AuthController(IUserService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }
        
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterDTO data)
        {
            try
            {
                _service.Register(data);
                return Ok("User successfully registered!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO data)
        {
            try
            {
                var token = _service.Login(data, _config);
                return Ok(token);
            }
            catch (Exception e)
            {
                return Unauthorized("User not found!");
            }
        }
    }
}