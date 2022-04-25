using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{

    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);   
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var itemToDelete = _context.Items.FirstOrDefault(x => x.Id == Id);

            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
