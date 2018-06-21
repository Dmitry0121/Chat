using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using ChatApp.Models; // класс Person

namespace ChatApp.Controllers
{
    public class AccountController : Controller
    {
        private List<Person> people = new List<Person>
        {
        new Person {Login="admin@gmail.com", Password="12345", Role = "admin" },
        new Person { Login="qwerty", Password="55555", Role = "user" }
        };

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
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Person person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}


















/*
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

const string sec = "ProEMLh5e_qnzdNUQrqdHPgp";
const string sec1 = "ProEMLh5e_qnzdNU";
var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
var securityKey1 = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec1));

var signingCredentials = new SigningCredentials(
    securityKey,
    SecurityAlgorithms.HmacSha512);

List<Claim> claims = new List<Claim>()
{
    new Claim("sub", "test"),
};

var ep = new EncryptingCredentials(
    securityKey1,
    SecurityAlgorithms.Aes128KW,
    SecurityAlgorithms.Aes128CbcHmacSha256);

var handler = new JwtSecurityTokenHandler();

var jwtSecurityToken = handler.CreateJwtSecurityToken(
    "issuer",
    "Audience",
    new ClaimsIdentity(claims),
    DateTime.Now,
    DateTime.Now.AddHours(1),
    DateTime.Now,
    signingCredentials,
    ep);


string tokenString = handler.WriteToken(jwtSecurityToken);

// Id someone tries to view the JWT without validating/decrypting the token,
// then no claims are retrieved and the token is safe guarded.
var jwt = new JwtSecurityToken(tokenString);
*/