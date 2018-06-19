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

        public void Create(Message message)
        {
            _context.Set<Message>().Add(message);
            _context.SaveChanges();
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
