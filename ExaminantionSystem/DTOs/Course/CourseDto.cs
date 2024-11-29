

namespace DTOs.Course
{
    public class CourseDto
    {

        public string Title { get; set; }
        public string Description { get; set; }

        public int Hours { get; set; }

        public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
