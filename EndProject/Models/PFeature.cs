using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class PFeature:BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public ICollection<ProductFeature>? ProductFeatures { get; set; }

    }
}
