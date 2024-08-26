
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsersTable> UsersTable { get; set; }
        public DbSet<BooksTable> BooksTable { get; set; }
     
    }
}

