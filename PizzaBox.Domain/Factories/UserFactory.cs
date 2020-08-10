using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
    public class UserFactory : IFactory<UserModel>
    {
        public UserModel Create()
        {
            var model = new UserModel();
            model.OldOrders= new List<OrderModel>();
            model.Order= new OrderFactory().Create();
            return model;
        }
    }
}