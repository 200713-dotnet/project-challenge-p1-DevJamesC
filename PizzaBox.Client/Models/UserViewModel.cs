using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Client.Models
{
    public class UserViewModel
    {
        private readonly PizzaBoxDbContext _db;

        public UserViewModel()
        {
            Stores = new List<StoreModel>() { new StoreModel { Name = "Dev's Pizza - Downtown" }, new StoreModel { Name = "Dev's Pizza - Westside" } };
            Order = new OrderFactory().Create();
            OldOrders = new List<OrderModel>();
        }
        public UserViewModel(PizzaBoxDbContext db, UserViewModel vm, bool usedByStore)//need to make this work for a shopViewModel.
        {
            _db = db;

            SelectedStore = vm.SelectedStore;
            Name = vm.Name;

            Order = new OrderFactory().Create();
            OldOrders = new List<OrderModel>();


            if (usedByStore)
            {
                var or = _db.Orders.Include(Pizzas => _db.Pizzas.ToList()).Include(Toppings => _db.Toppings.ToList()).Include(Crust => _db.Crust.ToList()).Include(Size => _db.Size.ToList());
                foreach (var order in or)
                {


                    OldOrders.Add(order);
                }
            }
            else
            {
                var or = _db.Orders.Include(Pizzas => _db.Pizzas.ToList()).Include(Toppings => _db.Toppings.ToList()).Include(Crust => _db.Crust.ToList()).Include(Size => _db.Size.ToList());
                foreach (var order in or)
                {
                    if(order.Name==Name)
                    {
                    OldOrders.Add(order);
                    }
                }
            }



        }
        public PizzaViewModel PizzaVm { get; set; }

        public List<OrderModel> OldOrders { get; set; }

        public OrderModel Order { get; set; }

        public List<StoreModel> Stores { get; set; }

        [Required]
        public string SelectedStore { get; set; }

        [Required]
        public string Name { get; set; }

        public void SetSelectedStore()
        {
            //connect user with Name to store with Name==selectedStore in the db

            var store = new StoreRepo(_db).GetStoreByName(SelectedStore);//making sure store exists
            var ur = new UserRepo(_db);
            var user = ur.GetUserByName(Name);//making sure user exists
            user.Store = store;
            ur.WriteUser(user);
        }
    }
}