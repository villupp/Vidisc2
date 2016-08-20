using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidisc2.Data;
using Vidisc2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidisc2.Controllers
{
    public class RoundsController : Controller
    {
        private DgContext _context;

        public RoundsController(DgContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Rounds.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Round round)
        {
            if (ModelState.IsValid)
            {
                _context.Rounds.Add(round);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(round);
        }
    }
}
