using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExaminantionSystem.Mapping
{
    public class EditExamDto
    {

        [Required]
        public ExamType Type { get; set; }

        [Required]
        public int MaxDuration { get; set; }

        [Required]
        public int TotalGrade { get; set; }


        [Required]
        public int PassMark { get; set; }

       // public DateOnly UpdatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //public ICollection<Result> Results { get; set; } = new List<Result>();

        // [ForeignKey("Course")]
        public int? CourseId { get; set; }


        //  [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
    }
}
