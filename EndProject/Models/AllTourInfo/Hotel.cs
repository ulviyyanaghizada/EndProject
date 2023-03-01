using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class Hotel:BaseNameEntity
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(300)]
        public string MealDescription { get; set; }
        [Required]
        [StringLength(100)]
        public string? BreakFast { get; set; }
        [Required]
        [StringLength(100)]
        public string? Lunch { get; set; }
        [Required]
        [StringLength(100)]
        public string? Supper { get; set; }
        public ICollection<TourDay>? TourDays { get; set; }
        public ICollection<HotelRoom>? HotelRooms { get; set; }
    }
}
