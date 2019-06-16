using System;
using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class AdminUserController : Controller
    {
        private readonly IUserService _service;

        public AdminUserController(IUserService service)
        {
            _service = service;
        }
        // GET: User
        [HttpGet]
        public ActionResult<UserDTO> Get()
        {
            var users = _service.GetAll();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _service.GetById(id);
            return Ok(user);
        }
        
        // POST: User/Create
        [HttpPost]
        public ActionResult Post([FromBody] RegisterDTO dto)
        {
            try
            {
                _service.Register(dto);
                return Ok("User successfully added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] UpdateUserDTO dto)
        {
            try
            {
                _service.Update(dto, id);
                return Ok("Successfully updated");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: User/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);
            return Ok("Successfully deleted");
        }
    }
}