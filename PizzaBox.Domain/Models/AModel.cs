namespace PizzaBox.Domain.Models
{//base model
  public abstract class AModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}