using ChatDataAccess.Abstract;
using ChatDataAccess.Entities;
using System.Linq;

namespace ChatDataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        Context _context;

        public UserRepository(string connectionString)
        {
            _context = new Context(connectionString);
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            return _context.Set<User>().Where(p => p.Login == login && p.Password == password).FirstOrDefault();
        }

        public void Create(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
