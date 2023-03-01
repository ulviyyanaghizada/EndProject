using EndProject.Models.Base;

namespace EndProject.Models
{
    public class QuestionCategory:BaseNameEntity
    {
        public ICollection<Question>? Questions { get; set; }
    }
}
