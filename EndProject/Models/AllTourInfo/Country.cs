using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class Country:BaseNameEntity
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Tour> Tours { get; set; }
        public int ContinentId { get; set; }
        public Continent? Continent { get; set; }
    }
}
