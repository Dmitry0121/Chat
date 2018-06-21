using AutoMapper;
using ChatService.Abstract;
using ChatService.DTO;
using ChatWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
//using System.Web.Http;

namespace ChatWeb.Controllers
{
    [Authorize]
    //[Route("api/[controller]")]
    public class ChatController : System.Web.Http.ApiController
    {
        IUserService _userService;
        IMessageService _messageService;
        IMapper _mapper;

        public ChatController(IUserService userService, IMessageService messageService)
        {
            if (userService == null || messageService == null)
            {
                throw new ArgumentNullException("Problem with services");
            }
            _userService = userService;
            _messageService = messageService;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, MessageViewModel>()).CreateMapper();
        }

        // [Route("getmessages")]
        [HttpGet]
        public IEnumerable<MessageViewModel> Get()
        {
            var messagesDto = _messageService.GetMessages();
            var message = _mapper.Map<IEnumerable<MessageDTO>, List<MessageViewModel>>(messagesDto);
            return message;
        }

        [HttpPost]
       // [Route("sendmessage")]
        public bool Post(MessageViewModel message)
        {
            try
            {
                var messageDto = _mapper.Map<MessageViewModel, MessageDTO>(message);
                _messageService.SendMessage(messageDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
