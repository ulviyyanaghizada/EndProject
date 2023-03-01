using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class TFeature:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public ICollection<TourFeature>? TourFeatures { get; set; }
    }
}
