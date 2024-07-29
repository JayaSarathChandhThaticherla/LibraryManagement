using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class AddBookModel
    {
        [Required(ErrorMessage ="Please enter the Book Name")]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }

    }
}

