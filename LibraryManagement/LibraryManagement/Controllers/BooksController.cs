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
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var book = _context.BooksTable.Find(id);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(BooksTable model)
        {
            if (ModelState.IsValid)
            {
                var obj = _context.BooksTable.Find(model.ID);
                obj.Author = model.Author;
                obj.BookName = model.BookName;
                obj.Price = model.Price;
                _context.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetBooks","Books");
            }
            return View(model);
        }

    }
}

