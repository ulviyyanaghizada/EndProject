using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Choose:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
