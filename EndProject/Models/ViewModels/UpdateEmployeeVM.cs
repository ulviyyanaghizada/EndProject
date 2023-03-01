using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateEmployeeVM
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Max 20 min 2 element ola bilər")]
        public string Name { get; set; }
        [Required]
        [MaxLength(30), MinLength(5)]
        public string Surname { get; set; }
        [MaxLength(20), MinLength(3)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(300)]
        public string About { get; set; }
        [MaxLength(40), MinLength(5)]
        public string Mail { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string? FacebookLink { get; set; }
        [Required]
        [StringLength(100)]
        public string? YoutubeLink { get; set; }
        [Required]
        [StringLength(100)]
        public string? TwitterLink { get; set; }
        [Required]
        [StringLength(100)]
        public string? InstagramLink { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public int PositionId { get; set; }
    }
}
