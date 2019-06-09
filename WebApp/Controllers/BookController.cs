using System;
using System.IO;
using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IImageService _image;

        public BookController(IBookService service, ICategoryService categoryService, IAuthorService authorService, IImageService image)
        {
            _service = service;
            _categoryService = categoryService;
            _authorService = authorService;
            _image = image;
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = _service.GetAll();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = _service.GetById(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var categories = _categoryService.GetAll();
            var authors = _authorService.GetAll();
            var data = new BookCategoryDTO()
            {
                Category = categories,
                Author = authors
            };
            return View(data);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, IFormFile file)
        {
            try
            {
                var path = _image.Upload(file);
                var dto = new InsertUpdateBookDTO()
                {
                    Title = collection["Book.Title"],
                    Description = collection["Book.Description"],
                    Pages = Int32.Parse(collection["Book.Pages"]),
                    Price = Double.Parse(collection["Book.Price"]),
                    CategoryId = Int32.Parse(collection["Book.CategoryId"]),
                    AuthorId = Int32.Parse(collection["Book.AuthorId"]),
                    ImageUrl = path
                };
                _service.Insert(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = _service.GetById(id);
            var categories = _categoryService.GetAll();
            var authors = _authorService.GetAll();
            var data = new BookCategoryDTO()
            {
                Book = book,
                Category = categories,
                Author = authors
            };
            return View(data);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, IFormFile file)
        {
            try
            {
                var dto = new InsertUpdateBookDTO()
                {
                    Title = collection["Book.Title"],
                    Description = collection["Book.Description"],
                    Pages = Int32.Parse(collection["Book.Pages"]),
                    Price = Double.Parse(collection["Book.Price"]),
                    CategoryId = Int32.Parse(collection["Book.CategoryId"]),
                    AuthorId = Int32.Parse(collection["Book.AuthorId"])
                };
                if (file != null)
                {
                    var book = _service.GetById(id);
                    _image.Delete(book.ImageUrl);
                    var path = _image.Upload(file);
                    dto.ImageUrl = path;
                }
                _service.Update(dto, id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = _service.GetById(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var book = _service.GetById(id);
                _image.Delete(book.ImageUrl);
                _service.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}