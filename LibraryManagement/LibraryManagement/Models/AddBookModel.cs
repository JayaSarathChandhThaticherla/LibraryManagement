using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class AddBookModel
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }

    }
}

