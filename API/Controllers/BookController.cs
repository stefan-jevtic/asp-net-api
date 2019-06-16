using System.Security.Claims;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : Controller
    {
        private IBookService _service;
        
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<PageResponse<BookDTO>> Get([FromQuery] BookSearch search)
        {
            var books = _service.Execute(search);
            return Ok(books);
        }
    }
}

/**
 *
 *    TODO: URADITI CRUD BEZ VALIDACIJE!!!
 * 
 */