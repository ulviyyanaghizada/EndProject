using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;
namespace EndProject.Models.AllTourInfo
{
    public class TrFeature : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public ICollection<TrekkingFeature>? TrekkingFeatures { get; set; }
    }
}
