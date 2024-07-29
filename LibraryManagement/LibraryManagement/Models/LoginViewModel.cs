using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
