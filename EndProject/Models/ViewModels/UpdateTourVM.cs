using EndProject.Models.AllTourInfo;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateTourVM
    {
        public ICollection<IFormFile>? OtherImages { get; set; }
        public IFormFile? PrimaryImage { get; set; }
        public ICollection<TourImage>? TourImages { get; set; }
        public List<int>? ImageIds { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Max 20 min 2 element ola bilər")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public double Price { get; set; }
        public byte GroupSize { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string Location { get; set; }

        public int CountryId { get; set; }
        public List<int> CategoriesIds { get; set; }
        public List<int> TFacilitiesIds { get; set; }
        public List<int> TFeaturesIds { get; set; }
        public IFormFile? Picture { get; set; }
        public string? PictureUrl { get; set; }
    }
}
