using System;

namespace ChatService.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeSend { get; set; }
    }
}