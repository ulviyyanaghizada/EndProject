using EndProject.Models.AllTourInfo;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateTrekkingVM
    {
		public int DifficultyId { get; set; }
		public List<int>? ImageIds { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public double Price { get; set; }
        public byte GroupSize { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Max 20 min 2 element ola bilər")]
        public string Name { get; set; }
        public List<int> TrFacilitiesIds { get; set; }
        public List<int> TrFeaturesIds { get; set; }
        public IFormFile? Picture { get; set; }
        public string? PictureUrl { get; set; }
        public ICollection<TrekkingImage>? TrekkingImages { get; set; }
        public ICollection<IFormFile>? OtherImages { get; set; }
        public IFormFile? PrimaryImage { get; set; }
        public string Location { get; set; }

    }
}
