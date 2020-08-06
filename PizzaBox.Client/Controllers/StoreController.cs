using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
    //Can handle CRUD requests (Create Update Delete)
    public class StoreController: Controller
    {

        private readonly PizzaBoxDbContext _db;

        public StoreController(PizzaBoxDbContext dbContext) //constructor dependency injection
        {
            _db=dbContext;
        }
       

    }
}