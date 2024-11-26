using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Instructor:Person
    {

        public decimal Salary { get; set; }
        public ICollection<InstructorCourses> instructorCourses { get; set; } = new List<InstructorCourses>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();



    }
}
