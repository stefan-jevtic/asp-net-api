using System;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishService _service;
        private readonly ICategoryService _categoryService;

        public DishController(IDishService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        // GET: Dish
        public ActionResult Index()
        {
            var dishes = _service.GetAll();
            return View(dishes);
        }

        // GET: Dish/Details/5
        public ActionResult Details(int id)
        {
            var dish = _service.GetById(id);
            return View(dish);
        }

        // GET: Dish/Create
        public ActionResult Create()
        {
            var categories = _categoryService.GetAll();
            var data = new DishCategoryDTO()
            {
                Category = categories
            };
            return View(data);
        }

        // POST: Dish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var dto = new DishDTO()
                {
                    Title = collection["Dish.Title"],
                    Ingredients = collection["Dish.Ingredients"],
                    Serving = collection["Dish.Serving"],
                    Price = Double.Parse(collection["Dish.Price"]),
                    CategoryId = Int32.Parse(collection["Dish.CategoryId"]),
                };
                _service.Insert(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dish/Edit/5
        public ActionResult Edit(int id)
        {
            var dish = _service.GetById(id);
            var categories = _categoryService.GetAll();
            var data = new DishCategoryDTO()
            {
                Dish = dish,
                Category = categories
            };
            return View(data);
        }

        // POST: Dish/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var dto = new DishDTO()
                {
                    Title = collection["Dish.Title"],
                    Ingredients = collection["Dish.Ingredients"],
                    Serving = collection["Dish.Serving"],
                    Price = Double.Parse(collection["Dish.Price"]),
                    CategoryId = Int32.Parse(collection["Dish.CategoryId"]),
                };
                _service.Update(dto, id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: Dish/Delete/5
        public ActionResult Delete(int id)
        {
            var dish = _service.GetById(id);
            return View(dish);
        }

        // POST: Dish/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
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