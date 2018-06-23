using ChatService.Abstract;
using ChatService.Services;
using Ninject.Modules;

namespace ChatWeb.Infrastructure
{
    public class NinjectModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IMessageService>().To<MessageService>();
        }
    }
}