using EndProject.DAL;
using EndProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EndProject.Controllers.Shop
{
    public class OurShopController : Controller
    {
        readonly AppDbContext _context;

        public OurShopController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM
            {

                Products = _context.Products?.Include(p => p.ProductColors).ThenInclude(pc => pc.Color)
                .Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).
                Include(p => p.ProductTags).ThenInclude(pt => pt.Tag).
                Include(p => p.ProductFeatures).ThenInclude(pf => pf.PFeature).Include(p => p.ProductImages).ToList()

            };

            return View(home);
        }
        public IActionResult WishList(int? id)
        {
            List<WishlistItemVM> items = new List<WishlistItemVM>();
            if (!string.IsNullOrEmpty(HttpContext.Request.Cookies["wishlist"]))
            {
                items = JsonConvert.DeserializeObject<List<WishlistItemVM>>((HttpContext.Request.Cookies["wishlist"]));
            }

            WishlistItemVM item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                item = new WishlistItemVM
                {
                    Id = (int)id,
                };
                items.Add(item);
            }
       
            string wishlist = JsonConvert.SerializeObject(items);
            HttpContext.Response.Cookies.Append("wishlist", wishlist, new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(1)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
