using EndProject.DAL;
using EndProject.Models;
using EndProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndProject.Controllers.Pages
{
    public class BookingController : Controller
    {
        readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            ViewBag.Trekkings = new SelectList(_context.Trekkings, nameof(EndProject.Models.AllTourInfo.Trekking.Id), nameof(EndProject.Models.AllTourInfo.Trekking.Name));
            ViewBag.Tours = new SelectList(_context.Tours, nameof(EndProject.Models.AllTourInfo.Tour.Id), nameof(EndProject.Models.AllTourInfo.Tour.Name));

            return View();
        }

        public IActionResult BookingPost (BookingVM model)
        {
            if (model == null) { return View("Error"); }
            if (!ModelState.IsValid) { return RedirectToAction("Index",model); }

            Booking booking = new Booking
            {
                Email = model.Email,
                FullName = model.FullName,
                Phones = model.Phones,
                guestNumber = model.guestNumber,
                date = model.date,
                TourId = model.TourId,
                
                

            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();


            return RedirectToAction("Index");

        }
    }
}
