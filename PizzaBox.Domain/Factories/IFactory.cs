namespace PizzaBox.Domain.Factories
{//Base factory Interface. This will be used instead of AFactory
  public interface IFactory<T> where T : class, new()
  {
    T Create();
  }
}
