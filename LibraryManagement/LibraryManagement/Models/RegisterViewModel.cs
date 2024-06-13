using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
      
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
