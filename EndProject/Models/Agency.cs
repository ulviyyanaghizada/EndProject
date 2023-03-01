using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;
namespace EndProject.Models
{
    public class Agency:BaseEntity
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
        public string ImageUrl { get; set; }
        public string ImageCoverUrl { get; set; }

    }
}
