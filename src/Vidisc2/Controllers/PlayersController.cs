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
    public class PlayersController : Controller
    {
        private DgContext _context;

        public PlayersController(DgContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Players.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                player.CreatedAt = DateTime.UtcNow;
                _context.Players.Add(player);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: /Players/Delete/2
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Player player = _context.Players.Where(p => p.PlayerId == id).FirstOrDefault();
            if (player == null)
            {
                return new NotFoundResult();
            }
            return View(player);
        }

        // POST: /Players/Delete/2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = _context.Players.Where(p => p.PlayerId == id).FirstOrDefault();
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }            
            return RedirectToAction("Index");
        }
    }
}
