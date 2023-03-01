using EndProject.DAL;
using EndProject.Models.ViewModels;
using EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using EndProject.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
  //  [Authorize(Roles = "Assistant,SuperAdmin")]

    public class InformationController : Controller
    {
        AppDbContext _context { get; }
        IWebHostEnvironment _env { get; }
        public InformationController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Informations.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateInformationVM create)
        {
            if (_context.Informations.ToList().Count >= 4) return RedirectToAction(nameof(Index));
            var image = create.Image;
            var result = image?.CheckValidate("image/", 600);
            if (result?.Length > 0)
            {
                ModelState.AddModelError("Image", result);
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            Information information = new Information()
            {

                Description = create.Description,
                Title = create.Title,
                Image = image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "images", "resource")),

            };
            _context.Informations.Add(information);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Information exist = _context.Informations.FirstOrDefault(c => c.Id == id);
            if (exist is null) return NotFound();
            exist.Image.DeleteFile(_env.WebRootPath, "assets/images/resource");
            _context.Informations.Remove(exist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return BadRequest();
            Information exist = _context.Informations.FirstOrDefault(i => i.Id == id);
            if (exist is null) return NotFound();
            UpdateInformationVM update = new UpdateInformationVM()
            {
                Title = exist.Title,
                Description = exist.Description,
                ImageUrl = exist.Image

            };
            ViewBag.Image = exist.Image;
            return View(update);
        }
        [HttpPost]
        public IActionResult Update(int? id, UpdateInformationVM update)
        {
            if (id is null || id == 0) return BadRequest();
            var image = update.Image;
            var result = image?.CheckValidate("image/", 600);
            if (result?.Length > 0)
            {
                ModelState.AddModelError("Image", result);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Image = _context.Informations.FirstOrDefault(c => c.Id == id).Image;
                return View();
            }
            Information exist = _context.Informations.FirstOrDefault(c => c.Id == id);
            if (exist is null) return NotFound();

            if (image != null)
            {
                string newImage = image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "images", "resource"));
                exist.Image.DeleteFile(_env.WebRootPath, "assets/images/resource");
                exist.Image = newImage;
            }
            exist.Title = update.Title;
            exist.Description = update.Description;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
