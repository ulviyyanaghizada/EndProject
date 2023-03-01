using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.Base
{
    public class BaseNameEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Max 20 min 2 element ola bilər")]
        public string Name { get; set; }
    }
}
