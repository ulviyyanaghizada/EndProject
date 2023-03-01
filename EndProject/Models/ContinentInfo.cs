using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class ContinentInfo:BaseNameEntity
    {
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [MaxLength(20), MinLength(3)]
        public string Number { get; set; }
        public string ImageUrl { get; set; }
    }
}
