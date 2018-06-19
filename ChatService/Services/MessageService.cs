using AutoMapper;
using ChatDataAccess.Abstract;
using ChatDataAccess.Entities;
using ChatService.Abstract;
using ChatService.DTO;
using System.Collections.Generic;

namespace ChatService.Services
{
    public class MessageService : IMessageService
    {
        IMessageRepository _messageRepository;
        IMapper _mapper;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Message, MessageDTO>()).CreateMapper();
        }

        public IEnumerable<MessageDTO> GetMessages()
        {
            var messages = _messageRepository.GetAll();
            return _mapper.Map<IEnumerable<Message>, List<MessageDTO>>(messages);
        }

        public void SendMessage(MessageDTO messageDto)
        {
            var message = _mapper.Map<MessageDTO, Message>(messageDto);
            _messageRepository.Create(message);
        }
    }
}
