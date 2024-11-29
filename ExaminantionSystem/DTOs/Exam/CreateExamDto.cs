using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Exam
{
    public class CreateExamDto
    {

        [Required]
        public ExamType Type { get; set; }

        [Required]
        public int MaxDuration { get; set; }

        [Required]
        public int TotalGrade { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PassMark { get; set; }

        public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public ICollection<int> QuestionsIds { get; set; }
        public int? CourseId { get; set; }


        public int? InstructorId { get; set; }



    }
}
