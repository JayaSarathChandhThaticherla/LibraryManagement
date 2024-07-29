using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class UsersTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

