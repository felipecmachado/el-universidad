using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Courses
{
    public class Course : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AdditionalInformation { get; private set; }

        public int Credits { get; private set; }
        public float MinimumGrade { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        public int Hours => Credits * 15;

        public static Course New(string title, string description, string additionalInfo, int credits, float grade)
        {
            var course = new Course()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Credits = credits,
                MinimumGrade = grade,
                CreatedAt = DateTime.UtcNow
            };

            return course;
        }

        public void Update(string title, string description, int credits, float grade)
        {
            Title = title;
            Description = description;
            Credits = credits;
            MinimumGrade = grade;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
