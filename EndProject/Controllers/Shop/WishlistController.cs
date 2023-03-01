using EndProject.DAL;
using EndProject.Models.ViewModels;
using EndProject.Models.ViewModels.Component;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EndProject.Controllers.Shop
{
    public class WishlistController : Controller
    {
        readonly AppDbContext _context;

        public WishlistController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM()
            {
                Wishlist = GetWishlist(),
            };
            return View(home);
        }
        public WishlistVM GetWishlist()
        {
            WishlistVM wishlist = new WishlistVM();
            List<WishlistItemVM> items = new List<WishlistItemVM>();
            if (!string.IsNullOrEmpty((HttpContext.Request.Cookies["wishlist"])))
            {
                items = JsonConvert.DeserializeObject<List<WishlistItemVM>>(HttpContext.Request.Cookies["wishlist"]);
            }
            if (items != null)
            {
                wishlist.Wishlists = new List<ProductWishlistItemVM>();
                foreach (var item in items)
                {
                    ProductWishlistItemVM product = new ProductWishlistItemVM();
                    product.Product = _context.Products.Include(p => p.ProductImages).FirstOrDefault(p => p.Id == item.Id);
                    //product.Count = item.Count;
                    wishlist.Wishlists.Add(product);
                    //wishlist.TotalPrice += product.Product.SellPrice * product.Count;
                }
            }
            return wishlist;
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
            });
            return RedirectToAction(nameof(Index));
        }


    }
}
