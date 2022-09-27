using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Courses
{
    public class Course : Entity, IAggregateRoot
    {
        public Course() { }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AdditionalInformation { get; private set; }

        public int Credits { get; private set; }
        public int MinimumGrade { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }
    }
}
