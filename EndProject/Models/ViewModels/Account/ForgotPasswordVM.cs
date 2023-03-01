using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class ForgotPasswordVM
    {
        [System.ComponentModel.DataAnnotations.Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
