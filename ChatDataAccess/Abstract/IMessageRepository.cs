using ChatDataAccess.Entities;
using System;
using System.Collections.Generic;

namespace ChatDataAccess.Abstract
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAll();
        IEnumerable<Message> GetNew(int messageId);
        int Create(Message message);
        void SaveChanges();
    }
}
