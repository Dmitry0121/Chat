using ChatService.DTO;
using System.Collections.Generic;

namespace ChatService.Abstract
{
    public interface IMessageService
    {
        IEnumerable<MessageDTO> GetMessages();
        IEnumerable<MessageDTO> GetNewMessages(int messageId);
        int SendMessage(MessageDTO message);       
    }
}