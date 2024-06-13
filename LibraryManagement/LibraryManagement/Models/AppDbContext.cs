using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UsersTable> UsersTables { get; set; }
    }
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
