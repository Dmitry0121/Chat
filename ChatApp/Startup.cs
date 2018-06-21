using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatService.Abstract;
using ChatService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChatApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddMvc();

            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IMessageService, MessageService>();

            //var serviceProvider = services.BuildServiceProvider();
           // var service = serviceProvider.GetService<IMessageService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)//, IUserService userService,
           // IMessageService messageService)//, IMessageService userService)
        {
            //app.Run(async (context) =>
            //{
            //    // await context.Response.WriteAsync(userService.GetMessages());
            //    IUserService messageSender = context.RequestServices.GetService<IUserService>();
            //    //context.Response.ContentType = "text/html;charset=utf-8";
            //    //await context.Response.WriteAsync(messageSender.Send());

            //   // await context.RequestServices.


            //});

            // By type.
          //  var service1 = (MessageService)serviceProvider.GetService(typeof(MessageService));

            // Using extension method.
           // var service2 = serviceProvider.GetService<MessageService>();


            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            
            app.UseMvc();
        }
    }
}



//<IUserService, UserService>();
 //           services.AddTransient<IMessageService