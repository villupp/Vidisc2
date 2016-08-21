using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidisc2.Data;
using Vidisc2.Models;

namespace Vidisc2.Controllers
{
    public class CoursesController : Controller
    {
        private DgContext _context;

        public CoursesController(DgContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Courses.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.CreatedAt = DateTime.UtcNow;
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: /Courses/Delete/2
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Course course = _context.Courses.Where(c => c.CourseId == id).FirstOrDefault();
            if (course == null)
            {
                return new NotFoundResult();
            }
            return View(course);
        }

        // POST: /Courses/Delete/2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = _context.Courses.Where(c => c.CourseId == id).FirstOrDefault();
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
