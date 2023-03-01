using EndProject.DAL;
using EndProject.Models;
using EndProject.Models.Gallery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
  //  [Authorize(Roles = "Admin,SuperAdmin")]

    public class QuestionCategoryController : Controller
    {
        AppDbContext _context { get; }
        public QuestionCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.QuestionCategories.ToList());
        }
        public IActionResult Delete(int id)
        {
            QuestionCategory category = _context.QuestionCategories.Find(id);
            if (category is null) return NotFound();
            _context.QuestionCategories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(QuestionCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.QuestionCategories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null) return BadRequest();
            QuestionCategory category = _context.QuestionCategories.Find(id);
            if (category is null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(int? id, QuestionCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id is null || id != category.Id) return BadRequest();
            QuestionCategory exist = _context.QuestionCategories.Find(id);
            if (exist is null) return NotFound();
            exist.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
