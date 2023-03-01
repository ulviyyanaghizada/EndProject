using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
  //  [Authorize(Roles = "Assistant,SuperAdmin,Admin")]

    public class CommentController : Controller
    {
        AppDbContext _context { get; }
        public CommentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Comments.Include(e => e.Employee).ThenInclude(e=>e.Position));
        }
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(_context.Employees.ToList(), nameof(Employee.Id), nameof(Employee.Name));
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment review)
        {
            if (!_context.Employees.Any(p => p.Id == review.EmployeeId))
            {
                ModelState.AddModelError("EmployeeId", "Bu Id'li employee yoxdur");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Employees = new SelectList(_context.Employees.ToList(), nameof(Employee.Id), nameof(Employee.Name));
                return View();
            }

            _context.Comments.Add(review);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Comment exist = _context.Comments.Include(e => e.Employee).FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();

            ViewBag.Employees = new SelectList(_context.Employees.ToList(), nameof(Employee.Id), nameof(Employee.Name));

            return View(exist);
        }
        [HttpPost]
        public IActionResult Update(int? id, Comment update)
        {
            if (id is null || id == 0) return BadRequest();

            if (!_context.Employees.Any(p => p.Id == update.EmployeeId))
            {
                ModelState.AddModelError("EmployeeId", "Bu Id'li employee yoxdur");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Employees = new SelectList(_context.Employees.ToList(), nameof(Employee.Id), nameof(Employee.Name));

                return View();
            }
            Comment exist = _context.Comments.Include(e => e.Employee).FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();

            exist.EmployeeId = update.EmployeeId;
            exist.Description = update.Description;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Comment exist = _context.Comments.FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();
            _context.Comments.Remove(exist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
