using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ChatService.Abstract;
using Chat.Models;
using AutoMapper;
using ChatService.DTO;

namespace Chat.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Chat")]
    public class ChatController : Controller
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

        public IActionResult GetMessages()
        {
            var messagesDto = _messageService.GetMessages();
            var message = _mapper.Map<IEnumerable<MessageDTO>, List<MessageViewModel>>(messagesDto);
            return Ok(message);
        }

        [HttpPost]
        public bool SendMessage (MessageViewModel message)
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