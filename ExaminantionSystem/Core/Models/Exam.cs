using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public  class Exam:BaseModel
    {
        public ExamType Type { get; set; }
        public int MaxDuration { get; set; }
        public int TotalGrade { get; set; }


        public int PassMark { get; set; }


        public ICollection<Result> Results { get; set; } = new List<Result>();

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course Course { get; set; }


        [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();


    }
}
