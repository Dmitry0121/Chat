using System;

namespace Chat.Models
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
