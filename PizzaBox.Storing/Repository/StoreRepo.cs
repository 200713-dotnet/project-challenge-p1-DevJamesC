using System.Collections;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repository
{
    public class StoreRepo
    {
        private PizzaBoxDbContext _db = PizzaBoxDbContext.Instance();

        public void WriteStore(StoreModel store)
        {
            _db.Store.Add(store);
        }

        public IEnumerable ReadStore()
        {
            return _db.Store;
        }
    }
}