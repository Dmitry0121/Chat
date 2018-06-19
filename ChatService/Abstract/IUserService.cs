using ChatService.DTO;

namespace ChatService.Abstract
{
    public interface IUserService
    {
        void Registration(UserDTO user);
        UserDTO LogIn(string login, string password);
    }
}
