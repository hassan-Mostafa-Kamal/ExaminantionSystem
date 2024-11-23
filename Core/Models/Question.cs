
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Models
{
    public class Question:BaseModel
    {
        public QuestionLevel  Level { get; set; }
        public string Body { get; set; }
        public decimal Score { get; set; }

        public ICollection<Choice> Choices { get; set; } = new List<Choice>();

        [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<ExamQuestion> QuetionExams { get; set; } = new List<ExamQuestion>();


    }
}
