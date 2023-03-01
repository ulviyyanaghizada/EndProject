using EndProject.Models.AllTourInfo;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class ContactVM
    {

        public int Id { get; set; }
        [MaxLength(30), MinLength(5)]
        public string FullName { get; set; }
        [MaxLength(40), MinLength(5)]
        public string Email { get; set; }
        [MaxLength(20), MinLength(3)]
        public string? PhoneNumber { get; set; }
        [StringLength(100)]
        public string subject { get; set; }
        [MaxLength(500), MinLength(2)]
        public string Message { get; set; }

    }
}
