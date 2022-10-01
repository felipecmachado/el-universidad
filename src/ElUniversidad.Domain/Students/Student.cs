using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Students
{
    public class Student : Entity, IAggregateRoot
    {
        public Student() { }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly BirthDate { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        public static Student New(string firstName, string lastName, DateOnly birthDate)
        {
            return new Student()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
