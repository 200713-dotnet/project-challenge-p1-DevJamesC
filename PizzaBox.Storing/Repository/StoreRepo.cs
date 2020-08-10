using System.Collections;
using System.Linq;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repository
{
    public class StoreRepo
    {
        private readonly PizzaBoxDbContext _db;

        public StoreRepo(PizzaBoxDbContext db)
        {
            _db=db;
        }

        public void WriteStore(StoreModel store)
        {
            _db.Store.Add(store);
            _db.SaveChanges();
        }

        public IEnumerable ReadStore()
        {
            return _db.Store;
        }

        public StoreModel GetStoreByName(string name)
        {
            var sm=_db.Store.FirstOrDefault(s=>s.Name==name);
            if(sm==null)
            {
                sm= new StoreFactory().Create();
                sm.Name=name;
                WriteStore(sm);
            }
            return sm;
        }
    }
}