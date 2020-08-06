using System.Collections;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repository
{
    public class OrderRepo
    {
        private PizzaBoxDbContext _db = PizzaBoxDbContext.Instance();

        public void WriteOrder(OrderModel order)
        {
            _db.Orders.Add(order);
        }

        public IEnumerable ReadOrder()
        {
            return _db.Orders;
        }
    }
}