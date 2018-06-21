using ChatService.Abstract;
using ChatService.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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