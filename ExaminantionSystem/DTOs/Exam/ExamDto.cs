using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Exam
{
    public class ExamDto
    {

       
        public ExamType Type { get; set; }

     
        public int MaxDuration { get; set; }


        public int TotalGrade { get; set; }


     
        public int PassMark { get; set; }

        public DateOnly CreatedOn { get; set; } 

        //public ICollection<Result> Results { get; set; } = new List<Result>();

        // [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public int CreatedBy { get; set; }

        //  [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
        // public Instructor Instructor { get; set; }
        //  public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    }
}
