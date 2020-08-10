using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repository
{
    public class UserRepo
    {
        private readonly PizzaBoxDbContext _db;

        public UserRepo(PizzaBoxDbContext db)
        {
            _db = db;
        }

        public void WriteUser(UserModel user)
        {
            var um = _db.Users.FirstOrDefault(u => u == user);
            _db.Users.Add(user);
            // if (um == null)
            // {
                
            // }
            // else
            // {
            //     _db.Users.Update(user);
            //     _db.Orders.Add(user.Order);
            // }

            _db.SaveChanges();
        }

        public IEnumerable ReadUser()
        {
            return _db.Users;
        }

        public UserModel GetUserByName(string name)
        {
            var um = _db.Users.FirstOrDefault(u => u.Name == name);
            if (um == null)
            {
                um = new UserFactory().Create();
                um.Name = name;
                WriteUser(um);
            }
            if (um.Order == null)
            {
                um.Order = new OrderFactory().Create();
            }
            if (um.OldOrders == null)
            {
                um.OldOrders = new List<OrderModel>();
            }

            return um;
        }
    }
}