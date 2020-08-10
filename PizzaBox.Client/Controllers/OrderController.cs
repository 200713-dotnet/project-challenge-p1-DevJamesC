using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Factories;
using Microsoft.AspNetCore.Cors;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Controllers
{

    [Route("/[controller]/[action]")] 
    public class OrderController : Controller
    {

        private readonly PizzaBoxDbContext _db;

        public OrderController(PizzaBoxDbContext dbContext) 
        {
            _db = dbContext;
        }

        // [Route("/Order")]
        //[Route("~/Order/Home")]
        public IActionResult Home(UserViewModel userViewModel)
        {
            var viewModel = new UserViewModel(_db, userViewModel, false);
           //var userModel=new UserRepo(_db).GetUserByName(userViewModel.Name);
           // viewModel.Order=userModel.Order;

            return View("Order", viewModel);
        }

        public IActionResult AddToOrder(UserViewModel userViewModel)
        {
            userViewModel.PizzaVm = new PizzaViewModel();
            return View("AddToOrder", userViewModel);

        }

        public IActionResult ResolveAddToOrder(UserViewModel userViewModel)
        {
            var pizza = new PizzaFactory().Create();
            pizza.Crust = new CrustModel() { Name = userViewModel.PizzaVm.Crust };
            pizza.Size = new SizeModel() { Name = userViewModel.PizzaVm.Size };
            foreach (var t in userViewModel.PizzaVm.SelectedToppings)
            {
                pizza.Toppings.Add(new ToppingModel() { Name = t });
            }
           // var userModel=new UserRepo(_db).GetUserByName(userViewModel.Name);
           // userModel.Order.Pizzas.Add(pizza);
           // new UserRepo(_db).WriteUser(userModel);
           userViewModel.Order.Pizzas.Add(pizza);
            return View("Order", userViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(UserViewModel userViewModel) //model binding
        {

            //if (ModelState.IsValid) // what is being validated? (The "required" attributes above parameters in the viewModel)
           // {
                var user= new UserFactory().Create();
                user.Name= userViewModel.Name;
                user.OldOrders=userViewModel.OldOrders;
                user.Order=userViewModel.Order;
                user.Store= new StoreRepo(_db).GetStoreByName(userViewModel.SelectedStore);
                user.Order.Name=user.Name;
                new UserRepo(_db).WriteUser(user);
                return Redirect("/user/complete");
           // }
           // return View("Order", userViewModel);


        }

        public IActionResult CheckPreviousOrders(UserViewModel userViewModel)
        {
            var viewModel = new UserViewModel(_db, userViewModel, false);
            return View("ViewOrder", viewModel);
        }
        // http status
        // 100 series = network
        // 200 series = all is good, 200-ok,201-modified,202-notmodified
        // 300 series = redirection, tempory, permanent
        // 400 series = user is stupid, client error, asking for something which does not exist
        // 500 series = dev is stupid, server borked

    }
}