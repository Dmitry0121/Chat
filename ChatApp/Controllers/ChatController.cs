using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatApp.Models;
using ChatService.Abstract;
using ChatService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        IUserService _userService;
        IMessageService _messageService;
        IMapper _mapper;

        public ChatController()//*IUserService userService, */IMessageService messageService)
        {
            //if (userService == null || messageService == null)
            //{
            //    throw new ArgumentNullException("Problem with services");
            //}
           // _userService = userService;
           // _messageService = messageService;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, MessageViewModel>()).CreateMapper();
        }

        [Authorize]
        [Route("getmessages")]
        public IActionResult GetMessages()
        {
            //var messagesDto = _messageService.GetMessages();
            //var message = _mapper.Map<IEnumerable<MessageDTO>, List<MessageViewModel>>(messagesDto);
            return Ok("message");
        }

        [HttpPost]
        [Authorize]
        [Route("sendmsessage")]
        public bool SendMessage (MessageViewModel message)
        {
            try
            {
                //var messageDto = _mapper.Map<MessageViewModel, MessageDTO>(message);
                //_messageService.SendMessage(messageDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}