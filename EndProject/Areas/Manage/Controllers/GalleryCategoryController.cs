using EndProject.DAL;
using EndProject.Models;
using EndProject.Models.Gallery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
  //  [Authorize(Roles = "Assistant,SuperAdmin")]

    public class GalleryCategoryController : Controller
    {
        AppDbContext _context { get; }
        public GalleryCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.GalleryCategories.ToList());
        }
        public IActionResult Delete(int id)
        {
            GalleryCategory category = _context.GalleryCategories.Find(id);
            if (category is null) return NotFound();
            _context.GalleryCategories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GalleryCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.GalleryCategories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null) return BadRequest();
            GalleryCategory category = _context.GalleryCategories.Find(id);
            if (category is null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(int? id, GalleryCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id is null || id != category.Id) return BadRequest();
            GalleryCategory exist = _context.GalleryCategories.Find(id);
            if (exist is null) return NotFound();
            exist.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
