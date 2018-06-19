using ChatService.DTO;
using System.Collections.Generic;

namespace ChatService.Abstract
{
    public interface IMessageService
    {
        IEnumerable<MessageDTO> GetMessages();
        void SendMessage(MessageDTO message);       
    }
}