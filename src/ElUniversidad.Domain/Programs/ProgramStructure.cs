using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Programs
{
    public class ProgramStructure : Entity
    {
        public Guid Id { get; private set; }
        public Guid ProgramId { get; private set; }

        public string Title { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        public virtual Program Program { get; set; }
        public virtual IEnumerable<AssignedCourse> Courses { get; set; }
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

        public static ProgramStructure New(Guid programId, string title)
        {
            return new ProgramStructure()
            {
                Id = Guid.NewGuid(),
                ProgramId = programId,
                Title = title,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}