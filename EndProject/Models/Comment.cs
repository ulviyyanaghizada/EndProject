using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;
namespace EndProject.Models
{
    public class Comment:BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
