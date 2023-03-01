using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class Trekking:BaseNameEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public double Price { get; set; }
        public byte GroupSize { get; set; }
        public string PictureUrl { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public int DifficultyId { get; set; }
        public Difficulty? Difficulty { get; set; }
        public ICollection<TrekkingImage>? TrekkingImages { get; set; }
        public ICollection<TrekkingFacilitie>? TrekkingFacilities { get; set; }
        public ICollection<TrekkingFeature>? TrekkingFeatures { get; set; }
        public ICollection<TrekkingDay> TrekkingDays { get; set; }
        public string Location { get; set; }
        public ICollection<Booking>? Bookings { get; set; } 

    }
}
