using AutoMapper;
using ChatDataAccess.Abstract;
using ChatDataAccess.Entities;
using ChatService.Abstract;
using ChatService.DTO;

namespace ChatService.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
        }

        public void Registration(UserDTO userDto)
        {
            var user = _mapper.Map<UserDTO, User>(userDto);
            _userRepository.Create(user);
        }

        public UserDTO LogIn(string login, string password)
        {
            var user = _userRepository.GetByLoginAndPassword(login, password);
            if (user != null)
            {
                return _mapper.Map<User, UserDTO>(user);
            }
            return null;
        }
    }
}
