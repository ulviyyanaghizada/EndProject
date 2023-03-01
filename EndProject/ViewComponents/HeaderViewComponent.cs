using EndProject.DAL;
using EndProject.Models.ViewModels;
using EndProject.Models.ViewModels.Basket;
using EndProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using EndProject.Models.ViewModels.Component;

namespace EndProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        readonly AppDbContext _context;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HeaderVM header = new HeaderVM()
            {
                Settings = _context.Settings.ToDictionary(s => s.Key, s => s.Value),
                Basket = GetBasket(),
              
            };
            return View(header);
        }
        BasketVM GetBasket()
        {
            BasketVM basket = new BasketVM();

            List<BasketItemVM> items =  new List<BasketItemVM>();
            if (!string.IsNullOrEmpty((HttpContext.Request.Cookies["basket"])))
            {
                items = JsonConvert.DeserializeObject<List<BasketItemVM>>(HttpContext.Request.Cookies["basket"]);
            }
            if (items!=null)
            {
                basket.Dress = new List<ProductBasketItemVM>();
                foreach (var item in items)
                {
                    ProductBasketItemVM product = new ProductBasketItemVM();
                    product.Product = _context.Products.Include(p => p.ProductImages).FirstOrDefault(p => p.Id == item.Id);
                    product.Count = item.Count;
                    basket.Dress.Add(product);
                    basket.TotalPrice += product.Product.SellPrice * product.Count;
                }
            }
            return basket;
        }

        //public WishlistVM GetWishlist()
        //{
        //    WishlistVM wishlist = new WishlistVM();
        //    List<WishlistItemVM> items = new List<WishlistItemVM>();
        //    if (!string.IsNullOrEmpty((HttpContext.Request.Cookies["wishlist"])))
        //    {
        //        items = JsonConvert.DeserializeObject<List<WishlistItemVM>>(HttpContext.Request.Cookies["wishlist"]);
        //    }
        //    if (items != null)
        //    {
        //        wishlist.Wishlists = new List<ProductWishlistItemVM>();
        //        foreach (var item in items)
        //        {
        //            ProductWishlistItemVM product = new ProductWishlistItemVM();
        //            product.Product = _context.Products.Include(p => p.ProductImages).FirstOrDefault(p => p.Id == item.Id);
        //            product.Count = item.Count;
        //            wishlist.Wishlists.Add(product);
        //            wishlist.TotalPrice += product.Product.SellPrice * product.Count;
        //        }
        //    }
        //    return wishlist;
        //}
    }
}
