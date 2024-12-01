using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Course
{
    public class EditCourseDto
    {

        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Range(1, 100)]
        public int Hours { get; set; }

       // public DateOnly UpdatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
