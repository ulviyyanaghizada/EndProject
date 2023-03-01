using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class ContactUs
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(30), MinLength(5)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(40), MinLength(5)]
        public string Email { get; set; }
        [MaxLength(20), MinLength(3)]
        public string? PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public  string subject { get; set; }
        [Required]
        [MaxLength(500), MinLength(2)]
        public string Message { get; set; }
        public bool IsSeen { get; set; } =false;

    }
}
