using System;
using System.Linq;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll().Select(c => new CategoryDTO() {
                    Id = c.Id,
                    Name = c.Name,
                    CreatedAt = c.CreatedAt
            });
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var categories = _unitOfWork.Category.Find(c => c.Id == id).Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefault();
            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
               var dto = new CategoryDTO()
                {
                    Name = collection["Name"],
                };
                _unitOfWork.Category.CreateCategory(dto);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
           var category = _unitOfWork.Category.Find(c => c.Id == id).Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefault();
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var dto = new CategoryDTO()
                {
                    Name = collection["Name"]
                };
                _unitOfWork.Category.UpdateCategory(dto, id);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _unitOfWork.Category.Find(c => c.Id == id).Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefault();
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _unitOfWork.Category.RemoveCategory(id);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}