using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatDataAccess.Entities
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Invalid login length")]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Invalid password length")]
        public string Password { get; set; }
    }
}
