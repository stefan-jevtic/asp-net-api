using System;
using System.Linq;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace WebApp.Controllers
{
    public class DishController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Dish
        public ActionResult Index()
        {
            var dishes = _unitOfWork.Dish.GetAll().Select(d => new DishDTO() {
                    Id = d.Id,
                    Title = d.Title,
                    Ingredients = d.Ingredients,
                    Serving = d.Serving,
                    Price = d.Price,
                    Name = d.Category.Name
            });
            return View(dishes);
        }

        // GET: Dish/Details/5
        public ActionResult Details(int id)
        {
            var dish = _unitOfWork.Dish.FindByExp(d => d.Id == id).Select(d => new DishDTO()
            {
                Id = d.Id,
                Title = d.Title,
                Ingredients = d.Ingredients,
                Serving = d.Serving,
                Price = d.Price,
                Name = d.Category.Name
            }).FirstOrDefault();
            return View(dish);
        }

        // GET: Dish/Create
        public ActionResult Create()
        {
            var categories = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Dish.InsertDish(dto);
                _unitOfWork.Save();

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
            var dish = _unitOfWork.Dish.FindByExp(d => d.Id == id).Select(d => new DishDTO()
            {
                Id = d.Id,
                Title = d.Title,
                Ingredients = d.Ingredients,
                Serving = d.Serving,
                Price = d.Price,
                CategoryId = d.Category.Id
            }).FirstOrDefault();
            var categories = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Dish.UpdateDish(dto, id);
                _unitOfWork.Save();
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
            var dish = _unitOfWork.Dish.FindByExp(d => d.Id == id).Select(d => new DishDTO()
            {
                Id = d.Id,
                Title = d.Title,
                Ingredients = d.Ingredients,
                Serving = d.Serving,
                Price = d.Price,
                Name = d.Category.Name
            }).FirstOrDefault();
            return View(dish);
        }

        // POST: Dish/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _unitOfWork.Dish.RemoveDish(id);
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