using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeSend { get; set; }
    }
}
