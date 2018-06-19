using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChatService.Abstract;
using Chat.Models;
using AutoMapper;
using ChatService.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Chat.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        IUserService _userService;
        IMessageService _messageService;
        IMapper _mapper;

        public AccountController(IUserService userService, IMessageService messageService)
        {
            if (userService == null || messageService == null)
            {
                throw new ArgumentNullException("Problem with services");
            }
            _userService = userService;
            _messageService = messageService;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, MessageViewModel>()).CreateMapper();
        }

        [HttpPost("/token")]
        public async Task Token()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];

            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;            
            var jwt = new JwtSecurityToken
            (
                issuer: TokenData.ISSUER,
                audience: TokenData.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(TokenData.LIFETIME)),
                signingCredentials: new SigningCredentials(TokenData.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _userService.LogIn(username, password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
            return null;
        }
    }
}