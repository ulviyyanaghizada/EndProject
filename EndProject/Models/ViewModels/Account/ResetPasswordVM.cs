using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class ResetPasswordVM
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(64)]
        public string NewPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(64)]
        [Compare(nameof(NewPassword))]
        public string ComfirmPassword { get; set; }
    }
}
