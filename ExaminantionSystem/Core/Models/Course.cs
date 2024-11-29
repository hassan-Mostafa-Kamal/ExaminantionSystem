using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Course:BaseModel
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }

        public int? InstructorId { get; set; }

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<InstructorCourses> CourseInstructors { get; set; } = new List<InstructorCourses>();

        public ICollection<StudentCourse> CourseStudents { get; set; } = new List<StudentCourse>();



    }
}
