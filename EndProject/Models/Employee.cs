using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Employee:BaseNameEntity
    {
        [Required]
        [MaxLength(30), MinLength(5)]
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(300)]
        public string About { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(40), MinLength(5)]
        public string Mail { get; set; }
        [Required]
        [StringLength(100)]
        public string? FacebookLink { get; set; }
        [Required]
        [StringLength(100)]
        public string? YoutubeLink { get; set; }
        [Required]
        [StringLength(100)]
        public string? TwitterLink { get; set; }
        [Required]
        [StringLength(100)]
        public string? InstagramLink { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }
        public ICollection<Comment>? Comments { get; set; }


    }
}
