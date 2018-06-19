using ChatDataAccess.Entities;
using System.Collections.Generic;

namespace ChatDataAccess.Abstract
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAll();
        void Create(Message message);
        void SaveChanges();
    }
}
