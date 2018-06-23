using ChatDataAccess.Abstract;
using ChatDataAccess.Concrete;
using Ninject.Modules;

namespace ChatService.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().WithConstructorArgument(connectionString);
            Bind<IMessageRepository>().To<MessageRepository>().WithConstructorArgument(connectionString);
        }
    }
}