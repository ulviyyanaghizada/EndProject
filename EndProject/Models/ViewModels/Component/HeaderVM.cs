using EndProject.Models.ViewModels.Basket;

namespace EndProject.Models.ViewModels.Component
{
    public class HeaderVM
    {
        public IDictionary<string, string> Settings { get; set; }
        public BasketVM Basket { get; set; }
        public WishlistVM Wishlist { get; set; }
    }
}
