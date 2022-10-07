using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Programs
{
    public class AssignedCourse : Entity
    {
        public Guid Id { get; private set; }
        public Guid ProgramStructureId { get; private set; }
        public Guid CourseId { get; private set; }

        public virtual ProgramStructure ProgramStructure { get; set; }
        public virtual Course Course { get; set; }

        public static AssignedCourse New(Guid programStructureId, Guid courseId)
        {
            var course = new AssignedCourse()
            {
                Id = Guid.NewGuid(),
                CourseId = courseId,
                ProgramStructureId = programStructureId
            };

            return course;
        }
    }
}
