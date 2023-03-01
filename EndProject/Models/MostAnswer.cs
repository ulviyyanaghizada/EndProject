using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class MostAnswer:BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(700)]
        public string Description { get; set; }
    }
}
