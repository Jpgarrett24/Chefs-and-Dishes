using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ChefsAndDishes.Models;

namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            Wrapper Wrapper = new Wrapper();
            Wrapper.AllChefs = _context.Chefs.Include(c => c.CreatedDishes).ToList();
            return View("Index", Wrapper);
        }

        [HttpGet("new")]
        public IActionResult ChefForm()
        {
            return View("AddChef");
        }

        [HttpPost("new/chef")]
        public IActionResult CreateChef(Chef Form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Form);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }

        [HttpGet("dishes")]
        public IActionResult DishesIndex()
        {
            Wrapper wrapper = new Wrapper();
            wrapper.AllChefs = _context.Chefs.Include(c => c.CreatedDishes).ToList();
            wrapper.AllDishes = _context.Dishes.Include(d => d.Creator).ToList();
            return View("DishesIndex", wrapper);
        }

        [HttpGet("dishes/new")]
        public IActionResult DishForm()
        {
            Wrapper wrapper = new Wrapper();
            wrapper.AllChefs = _context.Chefs.ToList();
            return View("AddDish", wrapper);
        }

        [HttpPost("dishes/create")]
        public IActionResult CreateDish(Wrapper Form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Form.OneDish);
                _context.SaveChanges();
                return RedirectToAction("DishesIndex");
            }
            else
            {
                return DishForm();
            }
        }
    }
}