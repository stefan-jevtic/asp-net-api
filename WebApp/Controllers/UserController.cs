using System;
using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _service.GetAll();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _service.GetById(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var dto = new AuthDTO()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    Password = AuthMiddleware.ComputeSha256Hash(collection["Password"]),
                };
                _service.Insert(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _service.GetById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Console.WriteLine(collection["IsDeleted"]);
                var dto = new AuthDTO()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    IsDeleted = Int32.Parse(collection["IsDeleted"])
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _service.GetById(id);
            return View(user);
        }

        // POST: User/Delete/5
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