using System.Collections;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repository
{
    public class UserRepo
    {
        private PizzaBoxDbContext _db = PizzaBoxDbContext.Instance();

        public void WriteUser(UserModel user)
        {
            _db.Users.Add(user);
        }

        public IEnumerable ReadUser()
        {
            return _db.Users;
        }
    }
}