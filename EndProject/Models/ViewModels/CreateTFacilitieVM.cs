using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class CreateTFacilitieVM
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public IFormFile Icon { get; set; }
    }
}
