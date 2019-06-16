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
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _service;

        public AdminCategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<CategoryDTO> Get()
        {
            var categories = _service.GetAll();
            return Ok(categories);
        }
        
        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> Get(int id)
        {
            var category = _service.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InsertUpdateCategoryDTO dto)
        {
            try
            {
               _service.Insert(dto);
               return Ok("Category successfully created!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // POST: Category/Edit/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InsertUpdateCategoryDTO dto)
        {
            try
            {
                _service.Update(dto, id);
                return Ok("Category successfully updated");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        
        // POST: Category/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteById(id);
                return Ok("Category successfully deleted!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}