using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatDataAccess.Entities
{
    [Table("Messages")]
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime DateTimeSend { get; set; }
    }
}