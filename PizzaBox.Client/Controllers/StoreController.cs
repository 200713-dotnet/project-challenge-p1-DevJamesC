using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]/[action]")]
    public class StoreController: Controller
    {

        private readonly PizzaBoxDbContext _db;

        public StoreController(PizzaBoxDbContext dbContext) //constructor dependency injection
        {
            _db=dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewOrders()
        {
            return View("ViewOrders",new UserViewModel(_db,new UserViewModel()));
        }
       

    }
}