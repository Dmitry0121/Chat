using ChatDataAccess.Entities;

namespace ChatDataAccess.Abstract
{
    public interface IUserRepository
    {
        User GetByLoginAndPassword(string login, string password);
        void Create(User user);
        void SaveChanges();
    }
}
