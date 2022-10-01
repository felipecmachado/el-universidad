using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Programs
{
    public class CourseStructure : Entity
    {
        public CourseStructure() { }

        public Guid Id { get; private set; }
        public Guid ProgramId { get; private set; }

        public string Title { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        public virtual IEnumerable<Course> Courses { get; private set; }

        public static CourseStructure New(Guid programId, string title, IEnumerable<Course> assignedCourses)
        {
            return new CourseStructure()
            {
                Id = Guid.NewGuid(),
                Title = title,
                ProgramId = programId,
                Courses = assignedCourses                
            };
        }
    }
}
