using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class TrekkingDay : BaseNameEntity
    {
        public int TrekkingId { get; set; }
        public Trekking? Trekking { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
