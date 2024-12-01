using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class StudentCourse:BaseModel
    {
        public int? StudentId { get; set; }
        public Student Student { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }
    }
}
