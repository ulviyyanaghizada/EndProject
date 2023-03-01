namespace EndProject.Models.ViewModels.Basket
{
    public class BasketVM
    {
        public ICollection<ProductBasketItemVM> Dress { get; set; }
        public double TotalPrice { get; set; }
    }
}
