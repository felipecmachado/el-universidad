using ElUniversidad.Application.Courses.Results;

namespace ElUniversidad.Application.Programs.Results
{
    public class ProgramStructuresResult
    {
        public IList<ProgramStructureResult> ProgramStructures { get; set; }

        public ProgramStructuresResult()
        {
            ProgramStructures = new List<ProgramStructureResult>();
        }
    }

    public class ProgramStructureResult
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public string ProgramTitle { get; set; }
        public string Title { get; set; }
        public int TotalHours { get; set; }
        public int TotalCredits { get; set; }
        public string CreatedAt { get; set; }
        public IList<CourseResult> AssignedCourses { get; set; }
    }
}
