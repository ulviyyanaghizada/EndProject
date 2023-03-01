using EndProject.Models.ViewModels.Basket;
using EndProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using EndProject.DAL;
using Stripe;
using System.Diagnostics;

namespace EndProject.Controllers.Shop
{
    public class CartController : Controller
    {
        readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            BasketVM basket = new BasketVM();

            List<BasketItemVM> items = new List<BasketItemVM>();
            if (!string.IsNullOrEmpty((HttpContext.Request.Cookies["basket"])))
            {
                items = JsonConvert.DeserializeObject<List<BasketItemVM>>(HttpContext.Request.Cookies["basket"]);
            }
            if (items != null)
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
            return View(basket);
        }
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken,
            });


            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Test Payment",
                Currency = "usd",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    {"OrderId","111" },
                    {"Postcode","LEE111" }
                }
            });

            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                return View();
            }
            else
            {

            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
