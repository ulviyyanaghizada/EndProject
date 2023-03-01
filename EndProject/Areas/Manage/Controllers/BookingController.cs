using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
 //   [Authorize(Roles = "Admin,SuperAdmin")]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Bookings.OrderByDescending(x=>x.Id).ToList());
        }

        public IActionResult Details(int Id)
        {
            Booking booking = _context.Bookings.FirstOrDefault(x => x.Id == Id);
            if (booking == null) { return BadRequest(); }
            return View(booking);

        }

        public IActionResult Comfirm(int Id)
        {
            Booking booking = _context.Bookings.FirstOrDefault(x => x.Id == Id);
            if (booking == null) { return BadRequest(); }

            booking.IsComfirm = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Ignore(int Id)
        {
            Booking booking = _context.Bookings.FirstOrDefault(x => x.Id == Id);
            if (booking == null) { return BadRequest(); }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
