namespace ElUniversidad.Application.Courses.Results
{
    public class CoursesResult
    {
        public IList<CourseResult> Courses { get; set; }

        public CoursesResult()
        {
            Courses = new List<CourseResult>();
        }
    }

    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
        public int Credits { get; set; }
        public float MinimumGrade { get; set; }
        public int Hours { get; set; }
    }
}
