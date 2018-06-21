﻿    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    namespace ChatApp.Controllers
    {
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            [Authorize]
            [Route("getlogin")]
            public IActionResult GetLogin()
            {
                return Ok($"Ваш логин: {User.Identity.Name}");
            }

            [Authorize]
            [Route("getrole")]
            public IActionResult GetRole()
            {
                return Ok("Ваша роль: администратор");
            }
        }
    }
