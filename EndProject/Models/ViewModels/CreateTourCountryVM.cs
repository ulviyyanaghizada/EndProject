using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class CreateTourCountryVM
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Max 20 min 2 element ola bilər")]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public int ContinentId { get; set; }
    }
}
