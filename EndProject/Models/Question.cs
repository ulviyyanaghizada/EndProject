using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Question:BaseEntity
    {
        [Required]
        [StringLength(100)]
       
        public string Title { get; set; }
        [Required]
        [StringLength(700)]
        public string Description { get; set; }
        public int QuestionCategoryId { get;set; }
        public QuestionCategory? QuestionCategory { get; set; }
    }
}
