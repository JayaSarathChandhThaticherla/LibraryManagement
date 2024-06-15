using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            var obj = _context.BooksTable.ToList();
            return View(obj);
        }
        [HttpGet]
        public IActionResult AddBooks()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooks(AddBookModel model)
        {
            if (ModelState.IsValid)
            {
                var obj = new BooksTable
                {
                    BookName = model.BookName,
                    Author = model.Author,
                    Price = model.Price,

                };
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetBooks","Books");
            }
            return View(model);
        }
    }
}

