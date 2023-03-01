using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateTFacilitieVM
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public IFormFile? Icon { get; set; }
        public string? IconUrl { get; set; }
    }
}
