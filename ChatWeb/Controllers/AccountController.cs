using AutoMapper;
using ChatService.Abstract;
using ChatService.DTO;
using ChatWeb.Models;
using System.Web.Mvc;

namespace ChatWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        IMapper _mapper;

        public AccountController(IUserService pUserService)
        {
            _userService = pUserService;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, MessageViewModel>()).CreateMapper();
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }
                
        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.LogIn(userViewModel.Login, userViewModel.Password);
                if (user != null)
                {
                    Session["Id"] = user.Id.ToString();
                    Session["Login"] = user.Login.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("LogIn", "Account");
                }
            }
            else
            {
                return View("LogIn", userViewModel);
            }
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<UserViewModel, UserDTO>(userViewModel);
                _userService.Registration(userDto);
            }
            return RedirectToAction("LogIn", "Account");
        }

        [Authorize]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("LogIn", "Account");
        }
    }
}