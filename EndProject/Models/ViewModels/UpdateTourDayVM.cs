using EndProject.Models.AllTourInfo;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateTourDayVM
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public int HotelId { get; set; }
        public int TourId { get; set; }
        public ICollection<IFormFile>? OtherImages { get; set; }
        public IFormFile? PrimaryImage { get; set; }
        public ICollection<TourDaysImage>? TourDaysImages { get; set; }
        public List<int>? ImageIds { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Max 20 min 2 element ola bilər")]
        public string Name { get; set; }

    }
}
