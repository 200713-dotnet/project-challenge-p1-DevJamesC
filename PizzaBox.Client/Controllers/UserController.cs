using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]/[action]")]
    //Can handle CRUD requests (Create Update Delete)
    public class UserController: Controller
    {

        private readonly PizzaBoxDbContext _db;

        public UserController(PizzaBoxDbContext dbContext) //constructor dependency injection
        {
            _db=dbContext;
        }
         [Route("/User")]
        [Route("~/User/Home")]
        [Route("~/User/Index")]
        public IActionResult Index()
        {
            return View();
        }
       

    }
}