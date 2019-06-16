using System;
using System.IO;
using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "1")]
    public class AdminBookController : Controller
    {
        private readonly IBookService _service;
        private readonly IImageService _image;

        public AdminBookController(IBookService service, IImageService image)
        {
            _service = service;
            _image = image;
        }
        // GET: Book
        [HttpGet]
        public ActionResult<BookDTO> Get()
        {
            var books = _service.GetAll();
            return Ok(books);
        }

        // GET: Book/Details/5
        [HttpGet("{id}")]
        public ActionResult<BookDTO> Get(int id)
        {
            var book = _service.GetById(id);
            return Ok(book);
        }
        
        // POST: Book/Create
        [HttpPost]
        public IActionResult Post([FromForm] InsertUpdateBookDTO dto, IFormFile file)
        {
            try
            {
                var path = _image.Upload(file);
                dto.ImageUrl = path;
                _service.Insert(dto);
                return Ok("Successfully inserted!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
        
        // POST: Book/Edit/5
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromForm]InsertUpdateBookDTO dto, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var book = _service.GetById(id);
                    _image.Delete(book.ImageUrl);
                    var path = _image.Upload(file);
                    dto.ImageUrl = path;
                }
                _service.Update(dto, id);
                return Ok("Book successfully updated!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        // POST: Book/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var book = _service.GetById(id);
                _image.Delete(book.ImageUrl);
                _service.DeleteById(id);
                return Ok("Book successfully deleted!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}