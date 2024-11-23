
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class StudentExam:BaseModel
    {

        [ForeignKey("Student")]
        public int? StudenId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Exam")]
        public int? ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
