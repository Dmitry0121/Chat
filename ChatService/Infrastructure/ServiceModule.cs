using ChatDataAccess.Abstract;
using ChatDataAccess.Concrete;
using Ninject.Modules;

namespace ChatService.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IMessageRepository>().To<MessageRepository>();
        }
    }
}