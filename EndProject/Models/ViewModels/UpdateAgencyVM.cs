using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateAgencyVM
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstTitle { get; set; }
        [Required]
        [StringLength(50)]
        public string SecondTitle { get; set; }
        [Required]
        [StringLength(50)]
        public string ThirdTitle { get; set; }
        public string Video { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageCover { get; set; }
        public string? ImageCoverUrl { get; set; }
    }
}
