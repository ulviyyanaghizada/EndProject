using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateHotelVM
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Max 20 min 2 element ola bilər")]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
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

        public List<int> RoomIds { get; set; }
    }
}
