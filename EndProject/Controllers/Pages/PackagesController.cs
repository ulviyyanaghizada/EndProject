using EndProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EndProject.Controllers.Pages
{
	public class PackagesController : Controller
	{
        readonly AppDbContext _context;

        public PackagesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
		{
            var trekking = _context.Trekkings.Include(t => t.TrekkingDays).Include(t => t.TrekkingFeatures).ThenInclude(t => t.TrFeature)
                .Include(t => t.TrekkingFacilities).ThenInclude(t => t.TrFacilitie).Include(t=>t.Difficulty).Include(t=>t.TrekkingImages).FirstOrDefault(x => x.Id == id); ;
			return View(trekking);
           
        }
	}
}
