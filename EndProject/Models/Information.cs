using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Information:BaseEntity
    {
        public string Image { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
