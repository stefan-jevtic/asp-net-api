using System;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class AdminAuthorController : Controller
    {
        private readonly IAuthorService _service;

        public AdminAuthorController(IAuthorService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<AuthorDTO> Get()
        {
            var authors = _service.GetAll();
            return Ok(authors);
        }
        
        [HttpGet("{id}")]
        public ActionResult<AuthorDTO> Get(int id)
        {
            var author = _service.GetById(id);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InsertUpdateAuthorDTO dto)
        {
            try
            {
                _service.Insert(dto);
                return Ok("Author successfully created!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // POST: Author/Edit/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InsertUpdateAuthorDTO dto)
        {
            try
            {
                _service.Update(dto, id);
                return Ok("Author successfully updated");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        
        // POST: Author/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteById(id);
                return Ok("Author successfully deleted!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}