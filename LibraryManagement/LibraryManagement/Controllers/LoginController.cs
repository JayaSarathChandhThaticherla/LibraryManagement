﻿using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LibraryManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.UsersTables.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // User found, redirect to dashboard or other protected area
                    return RedirectToAction("Index", "Home");
                }
            }
                return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                var obj = new UsersTable
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                };
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Register", "Login");


            }
            return View(model);
        }

    }
}
