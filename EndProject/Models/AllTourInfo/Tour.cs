using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class Tour:BaseNameEntity
    {
        [Required]
        [StringLength(500)]
        public string  Description { get; set; }
        [Required]
        [StringLength(50)]
        public string  Title { get; set; }
        public string PictureUrl { get; set; }
        public double Price { get; set; }
        public byte GroupSize { get; set; }
        public ICollection<TourImage>? TourImages { get; set; }
        public ICollection<TourFacilitie>? TourFacilities { get; set; }
        public ICollection<TourFeature>? TourFeatures { get; set; }
        public ICollection<TourDay> TourDays { get; set; }
        public ICollection<TourCategory>? TourCategories { get; set; } 
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public string Location { get; set; }
        public ICollection<Booking>? Bookings { get; set; }

    }
}
