using ChatDataAccess.Abstract;
using ChatDataAccess.Entities;
using System.Linq;

namespace ChatDataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        Context _context;

        public UserRepository()
        {
            _context = new Context();
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            //return _context.Set<User>().SingleOrDefault(p => p.Login == login && p.Password == password);
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
