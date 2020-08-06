using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
     
    [Route("[controller]/[action]")]
    //Can handle CRUD requests (Create Put Update Delete)
    public class PizzaController: Controller
    {

        private readonly PizzaBoxDbContext _db;

        public PizzaController(PizzaBoxDbContext dbContext) //constructor dependency injection
        {
            _db=dbContext;
        }

        
       // [Route("/Pizza")]
        //[Route("~/Pizza/Get")]
        [HttpGet()] //makes sure that Get() will only listen to get requests. DUE TO HTTP HAVING NO OVERLOADING, WE NEED TO SPECIFY INPUT. IF THE METHOD NAME WAS DIFFERENT, WE STILL NEED TO SPECIFY
         public IActionResult Get() //using IEnumerable instead of list because List only works for c#. The server will not know what a List is
        {
            ViewBag.PizzaList = _db.Pizzas.ToList(); //dyanmic object. used for View("Home");
            //ViewData or TempData can also be used. they are dictonary based
            //ViewData["PizzaList"] =_db.Pizzas.ToList(); //dictonary
            //TempData["PizzaList"]= _db.Pizzas.ToList();//Data remains live for the duration of request to server. the other two are deleted after they travel to from the server to the client
            //temp data is only good for redirection. otherwise it's overkill
            return View("Home2",_db.Pizzas.ToList());
        }

        [HttpGet("{id}")]
        //[HttpPost] //not a good idea. If we want to support all verbs, then just remove action filters
        public PizzaModel Get(int id)
        {
            return _db.Pizzas.SingleOrDefault(p => p.Id ==id); //Single will make sure there is ONLY ONE result. First will return the first of a group of results
        }

       

    }//read about ACTION FILTERS (auth (authorization & authentication), response (return), exeption, resource (additional Info), action (the method) ) 
    // (ORDER OF OPERATIONS: Auth ->Action ->Resource ->Response ->Exception)
}