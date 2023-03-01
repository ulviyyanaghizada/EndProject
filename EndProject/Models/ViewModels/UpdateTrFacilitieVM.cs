using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateTrFacilitieVM
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public IFormFile? Icon { get; set; }
        public string? IconUrl { get; set; }
    }
}
