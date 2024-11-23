using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Student:BaseModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string  Address { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BarthDate { get; set; }
        public int Year { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        public Result Result { get; set; }


    }
}
