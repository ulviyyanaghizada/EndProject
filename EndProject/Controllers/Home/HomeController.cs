using EndProject.DAL;
using EndProject.Models;
using EndProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;

namespace EndProject.Controllers.Home
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM {

                Entries = _context.Entries,
                Chooses = _context.Chooses.ToList(),
                Agencies = _context.Agencies,
                Brands = _context.Brands,
                Products = _context.Products.Include(p => p.ProductImages),
                Continents = _context.Continents.ToList(),
                Countires = _context.Countries.Include(c => c.Tours).ToList(),
                Comments = _context.Comments.Include(c => c.Employee).ThenInclude(e => e.Position).ToList(),
                Difficulties = _context.Difficulties.ToList(),
                Trekkings = _context.Trekkings.Include(t => t.Difficulty).Include(t => t.TrekkingImages).Include(t => t.TrekkingDays).ToList()

            };

            return View(home);
        }
       public IActionResult SetSession(string key,string value)
        {
            HttpContext.Session.SetString(key, value);
            return Content("Ok");
        }
        public IActionResult GetSession(string key)
        {
           string value =  HttpContext.Session.GetString(key);
            return Content(value);
        }
        public IActionResult SetCookies(string key, string value)
        {
            HttpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(1)
            });
            return Content("Ok");
        }
        public IActionResult GetCookies(string key)
        {
            return Content(HttpContext.Request.Cookies[key]);
        }

        public IActionResult RemoveItem(int id)
        {
            List<BasketItemVM> items = new List<BasketItemVM>();
            if (!string.IsNullOrEmpty((HttpContext.Request.Cookies["basket"])))
            {
                items = JsonConvert.DeserializeObject<List<BasketItemVM>>((HttpContext.Request.Cookies["basket"]));
            }
            BasketItemVM item = items.FirstOrDefault(i => i.Id == id);
            if (item!=null)
            {
                items.Remove(item);
            }
            string basket = JsonConvert.SerializeObject(items);
            HttpContext.Response.Cookies.Append("basket", basket, new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(1)
            });
            return RedirectToAction("Index");
        }
        public IActionResult AddBasket(int? id)
        {

            List<BasketItemVM> items = new List<BasketItemVM>();

            if (!string.IsNullOrEmpty((HttpContext.Request.Cookies["basket"])))
            {
                items = JsonConvert.DeserializeObject<List<BasketItemVM>>((HttpContext.Request.Cookies["basket"]));
            }
            BasketItemVM item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                item = new BasketItemVM
                {
                    Id = (int)id,
                    Count = 1
                };
                items.Add(item);
            }
            else
            {
                item.Count++;
            }
            string basket = JsonConvert.SerializeObject(items);
            HttpContext.Response.Cookies.Append("basket", basket, new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(1)
            }) ;
            return RedirectToAction(nameof(Index));
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
            else
            {
                    
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