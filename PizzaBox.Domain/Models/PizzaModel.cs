using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class PizzaModel : PricedItemModel
  {
    public CrustModel Crust { get; set; }
    public SizeModel Size { get; set; }
    public List<ToppingModel> Toppings { get; set; }

    public override string ToString() 
    {
      var sb= new StringBuilder();
      int i=0;
      foreach (var t in Toppings)
      {
        if(i==0||i==1)
        {
          sb.Append(t.Name);
        }else{
           sb.Append($", {t.Name}");
        }
          i+=1;
      }

      return $"${GetPrice()} .... Size: {Size.Name}, Crust: {Crust.Name}, Toppings: {sb.ToString()}";
    }


    public decimal GetPrice()
    {
        decimal topPrice=0;

        foreach (var t in Toppings)
        {
            topPrice+=t.Price;
        }

      return Price+topPrice+Crust.Price+Size.Price;
    }
  }
}
