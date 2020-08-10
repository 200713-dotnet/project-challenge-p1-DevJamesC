using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class UserModel : AModel
  {

    public StoreModel Store { get; set; }

    public OrderModel Order { get; set; }
    public List<OrderModel> OldOrders { get; set; }
  }
}