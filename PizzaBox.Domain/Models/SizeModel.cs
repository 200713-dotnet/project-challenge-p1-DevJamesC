namespace PizzaBox.Domain.Models
{
  public class SizeModel : PricedItemModel
  {
      public override string ToString()
      {
          return Name;
      }
  }
}