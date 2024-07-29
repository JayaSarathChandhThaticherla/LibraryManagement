using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class AddBookModel
    {
        [Required(ErrorMessage ="Please enter the Book Name")]
        public string BookName { get; set; }
        [Required(ErrorMessage ="Please enter the Author Name")]
        public string Author { get; set; }
        [Required(ErrorMessage ="Please enter valid price")]
        public int Price { get; set; }

    }
}

