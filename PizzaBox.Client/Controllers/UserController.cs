using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Factories;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]/[action]")]
    //Can handle CRUD requests (Create Update Delete)
    public class UserController : Controller
    {

        private readonly PizzaBoxDbContext _db;

        public UserController(PizzaBoxDbContext dbContext) //constructor dependency injection
        {
            _db = dbContext;
        }
        [Route("/User")]
        [Route("~/User/Home")]
        [Route("~/User/Index")]
        public IActionResult Index(UserViewModel userViewModel)
        {
            return View("Index", userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectStore(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var viewModel= new UserViewModel(_db, userViewModel);
                //viewModel.SetSelectedStore();
                return RedirectToAction("Home","Order",viewModel);
               
                
            }

            return View("Index", userViewModel);
        }

        public IActionResult Complete()
        {
            return View();
        }


    }
}