using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context, ILogger<BooksController> logger)
        { 
            _context = context;
            _logger = logger;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login", "Login");
            }


            var obj = _context.BooksTable.ToList();
            return View(obj);
        }
        [HttpGet]
        public IActionResult AddBooks()
        {
                if (HttpContext.Session.GetString("Email") == null)
            {
                _logger.LogWarning("User not authenticated. Redirecting to Login.");
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooks(AddBookModel model)
        {
            _logger.LogInformation("AddBooks action started.");
            if (HttpContext.Session.GetString("Email") == null)
            {
                _logger.LogWarning("User not authenticated. Redirecting to Login.");
                return RedirectToAction("Login", "Login");
            }
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
            else
            {
                // Log an error message without an exception
                _logger.LogError("Model state is invalid.");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var book = _context.BooksTable.Find(id);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(BooksTable model)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login", "Login");
            }
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
        
        
        public async Task<ActionResult> DeleteBook(int id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var obj = _context.BooksTable.Find(id);
            if (obj != null)
            {
                _context.BooksTable.Remove(obj);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("GetBooks", "Books");
        }


        [HttpGet]
        public ActionResult Search(string query)
        {
            var results = string.IsNullOrEmpty(query) ?
                          _context.BooksTable.ToList() :
                          _context.BooksTable.Where(b => b.BookName.Contains(query)).ToList();

            return View("Search", results);
        }

    }
}

