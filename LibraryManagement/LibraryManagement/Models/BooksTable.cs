using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
	public class BooksTable
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string BookName { get; set; }
		[Required]
		public string Author { get; set; }
		[Required]
		public int Price { get; set; }

	}
}

