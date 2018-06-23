using ChatDataAccess.Abstract;
using ChatDataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ChatDataAccess.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        Context _context;

        public MessageRepository()
        {
            _context = new Context();
        }

        public IEnumerable<Message> GetAll()
        {
            IQueryable<Message> query = _context.Set<Message>();
            return query.OrderBy(p=>p.DateTimeSend);
        }

        public IEnumerable<Message> GetNew(int messageId)
        {
            IQueryable<Message> query = _context.Set<Message>().Where(p=>p.Id > messageId);
            return query.OrderBy(p => p.DateTimeSend);
        }

        public int Create(Message message)
        {
            _context.Set<Message>().Add(message);
            _context.SaveChanges();
            SaveChanges();
            return message.Id;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
