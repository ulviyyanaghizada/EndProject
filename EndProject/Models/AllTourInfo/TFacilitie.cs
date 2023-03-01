using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class TFacilitie:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public ICollection<TourFacilitie>? TourFacilities { get; set; }
    }
}
