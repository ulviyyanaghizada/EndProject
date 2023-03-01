using EndProject.Models.AllTourInfo;
using EndProject.Models.Gallery;
using EndProject.Models.ViewModels.Basket;
using System.Drawing;

namespace EndProject.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Entry> Entries { get; set; }
        public List<Choose> Chooses { get; set; }
        public IEnumerable<Agency> Agencies { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public IEnumerable<OfficeMap> OfficeMaps { get; set; }
        public IEnumerable<ContinentInfo> ContinentInfos { get; set; }
        public List<MostFrequent> MostFrequents { get; set; }
        public List<MostAnswer> MostAnswers { get; set; }
        public List<Condition> Conditions { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public List<QuestionCategory> QuestionCategories { get; set; }
        public List<Question> Questions { get; set; }
        public Product Product { get; set; }
        public ICollection<Continent> Continents { get; set; }
        public ICollection<Country> Countires { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Information> Informations { get; set; }
        public ICollection<EndProject.Models.Gallery.Gallery> Galleries { get; set; }
        public ICollection<GalleryCategory> GalleryCategories { get; set; }
        public ICollection<Trekking> Trekkings { get; set; }
        public ICollection<Difficulty> Difficulties { get; set; }
        public WishlistVM Wishlist { get; set; }
    }
}
