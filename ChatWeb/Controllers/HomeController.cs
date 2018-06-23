using AutoMapper;
using ChatService.Abstract;
using ChatService.DTO;
using ChatWeb.Infrastructure;
using ChatWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ChatWeb.Controllers
{
    [MyAuthorizeAttribute]
    public class HomeController : Controller
    {
        IUserService _userService;
        IMessageService _messageService;
        IMapper _mapper;

        public HomeController(IUserService userService, IMessageService messageService)
        {
            if (userService == null || messageService == null)
            {
                throw new ArgumentNullException("Problem with services");
            }
            _userService = userService;
            _messageService = messageService;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, MessageViewModel>()).CreateMapper();
        }

        public ActionResult Index()
        {
            if (Session["Id"] != null)
                ViewBag.UserId = Session["Id"];
            return View();
        }

        public string GetMessages()
        {
            var messagesDto = _messageService.GetMessages();
            var message = _mapper.Map<IEnumerable<MessageDTO>, List<MessageViewModel>>(messagesDto);
            return JsonConvert.SerializeObject(message);
        }

        public string GetNewMessages(int currentUserId)
        {
            var messagesDto = _messageService.GetNewMessages(currentUserId);
            var message = _mapper.Map<IEnumerable<MessageDTO>, List<MessageViewModel>>(messagesDto);
            return JsonConvert.SerializeObject(message);
        }

        [HttpPost]
        public int SendMessage(MessageViewModel message)
        {
            var messageDto = _mapper.Map<MessageViewModel, MessageDTO>(message);
            int id = _messageService.SendMessage(messageDto);
            return id;
        }
    }
}