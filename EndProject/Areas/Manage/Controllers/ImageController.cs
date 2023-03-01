using EndProject.DAL;
using EndProject.Models.Gallery;
using EndProject.Models.ViewModels;
using EndProject.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
 //   [Authorize(Roles = "Assistant,SuperAdmin")]

    public class ImageController : Controller
    {
        AppDbContext _context { get; }
        IWebHostEnvironment _env { get; }
        public ImageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Galleries.Include(e => e.GalleryCategory));
        }
        public IActionResult Create()
        {
            ViewBag.GalleryCategories = new SelectList(_context.GalleryCategories.ToList(), nameof(GalleryCategory.Id), nameof(GalleryCategory.Name));
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateGalleryVM create)
        {
            var image = create.Image;
            var result = image?.CheckValidate("image/", 600);
            if (result?.Length > 0)
            {
                ModelState.AddModelError("Image", result);
            }
            if (!_context.GalleryCategories.Any(p => p.Id == create.GalleryCategoryId))
            {
                ModelState.AddModelError("PositionId", "Bu Id'li category yoxdur");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.GalleryCategories = new SelectList(_context.GalleryCategories.ToList(), nameof(GalleryCategory.Id), nameof(GalleryCategory.Name));
                return View();
            }
            Gallery gallery = new Gallery()
            {

                ImageUrl = image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "images", "gallery")),
                GalleryCategoryId = create.GalleryCategoryId
            };
            _context.Galleries.Add(gallery);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Gallery exist = _context.Galleries.Include(e => e.GalleryCategory).FirstOrDefault(g => g.Id == id);
            if (exist is null) return NotFound();
            UpdateGalleryVM update = new UpdateGalleryVM()
            {
                ImageUrl = exist.ImageUrl,
                GalleryCategoryId = exist.GalleryCategoryId
            };
            ViewBag.GalleryCategories = new SelectList(_context.GalleryCategories.ToList(), nameof(GalleryCategory.Id), nameof(GalleryCategory.Name));
            ViewBag.Image = exist.ImageUrl;
            return View(update);
        }
        [HttpPost]
        public IActionResult Update(int? id, UpdateGalleryVM update)
        {
            if (id is null || id == 0) return BadRequest();
            var image = update.Image;
            var result = image?.CheckValidate("image/", 600);
            if (result?.Length > 0)
            {
                ModelState.AddModelError("Image", result);
            }
            if (!_context.GalleryCategories.Any(p => p.Id == update.GalleryCategoryId))
            {
                ModelState.AddModelError("PositionId", "Bu Id'li category yoxdur");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.GalleryCategories = new SelectList(_context.GalleryCategories.ToList(), nameof(GalleryCategory.Id), nameof(GalleryCategory.Name));
                ViewBag.Image = _context.Galleries.FirstOrDefault(g => g.Id == id).ImageUrl;
                return View();
            }
            Gallery exist = _context.Galleries.Include(e => e.GalleryCategory).FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();

            if (image != null)
            {
                string newImage = image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "images", "gallery"));
                exist.ImageUrl.DeleteFile(_env.WebRootPath, "assets/images/gallery");
                exist.ImageUrl = newImage;
            }
            exist.GalleryCategoryId = update.GalleryCategoryId;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Gallery exist = _context.Galleries.FirstOrDefault(e => e.Id == id);
            if (exist is null) return NotFound();
            exist.ImageUrl.DeleteFile(_env.WebRootPath, "assets/images/gallery");
            _context.Galleries.Remove(exist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
