using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Factories;
using Microsoft.AspNetCore.Cors;

namespace PizzaBox.Client.Controllers
{
    
    [Route("/[controller]/[action]")] //CURRENTLY ONLY THE METHOD ROUTING (also called attribute routing) WORKS. THIS LINE IS EFFECTIVLY USELESS
    //[Route("/[Controller]")]// if using controller/method routing, then don't use global routing
    //[EnableCors()]//just using default cors
    public class OrderController : Controller
    {
        
        private readonly PizzaBoxDbContext _db;

        public OrderController(PizzaBoxDbContext dbContext) //constructor dependency injection
        {
            _db = dbContext;
        }
          
       // [Route("/Order")]
        //[Route("~/Order/Home")]
        public IActionResult Home()
        {
            return View("Order", new PizzaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel) //model binding
        {
            
            if (ModelState.IsValid) // what is being validated? (The "required" attributes above parameters in the viewModel)
            {
                var p= new PizzaFactory();
                //_db.Order.Add(pizzaViewModel); //add pizza to order
                //repository.Create(pizzaViewModel);
                //return View("User"); //needs to be a view in order, or shared
                return Redirect("/user/index");//two ways to redirect: 1, returns a message to browser to ask for new request. 2, 
                //http 300-series status (302, specifically. a temporary redirect). we can do a perminate redirect. (means don't ever use the POST redirect steps again)
            }
            return View("Order", pizzaViewModel);


        }
        // http status
        // 100 series = network
        // 200 series = all is good, 200-ok,201-modified,202-notmodified
        // 300 series = redirection, tempory, permanent
        // 400 series = user is stupid, client error, asking for something which does not exist
        // 500 series = dev is stupid, server borked

    }
}