using EndProject.DAL;
using EndProject.Models.ViewModels;
using EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
  //  [Authorize(Roles = "Admin,SuperAdmin")]

    public class QuestionController : Controller
    {
        AppDbContext _context { get; }
        public QuestionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Questions.Include(e => e.QuestionCategory));
        }
        public IActionResult Create()
        {
            ViewBag.QuestionCategories = new SelectList(_context.QuestionCategories.ToList(), nameof(QuestionCategory.Id), nameof(QuestionCategory.Name));
            return View();
        }
        [HttpPost]
        public IActionResult Create(Question create)
        {
            
            if (!_context.QuestionCategories.Any(p => p.Id == create.QuestionCategoryId))
            {
                ModelState.AddModelError("QuestionCategoryId", "Bu Id'li category yoxdur");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.QuestionCategories = new SelectList(_context.QuestionCategories.ToList(), nameof(QuestionCategory.Id), nameof(QuestionCategory.Name));
                return View();
            }
            Question question = new Question()
            {
                Description = create.Description,
                QuestionCategoryId = create.QuestionCategoryId,
                Title=create.Title
            };
            _context.Questions.Add(question);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Question exist = _context.Questions.Include(e => e.QuestionCategory).FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();
            ViewBag.QuestionCategories = new SelectList(_context.QuestionCategories.ToList(), nameof(QuestionCategory.Id), nameof(QuestionCategory.Name));
            return View(exist);
        }
        [HttpPost]
        public IActionResult Update(int? id, Question update)
        {
            if (id is null || id == 0) return BadRequest();
            
            if (!_context.QuestionCategories.Any(p => p.Id == update.QuestionCategoryId))
            {
                ModelState.AddModelError("QuestionCategoryId", "Bu Id'li category yoxdur");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.QuestionCategories = new SelectList(_context.QuestionCategories.ToList(), nameof(QuestionCategory.Id), nameof(QuestionCategory.Name));

                return View();
            }
            Question exist = _context.Questions.Include(e => e.QuestionCategory).FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();

          
            exist.QuestionCategoryId = update.QuestionCategoryId;
            exist.Description = update.Description;
            exist.Title = update.Title;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Question exist = _context.Questions.FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();
            _context.Questions.Remove(exist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
