using ElUniversidad.Domain.Programs.Enums;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Programs
{
    public class Program : Entity, IAggregateRoot
    {
        public Program() { }

        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AdditionalInformation { get; private set; }
        public DegreeType Degree { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        public ICollection<Offer> Offers { get; private set; } = new List<Offer>();

        public static Program New(string code, string title, string description, DegreeType degree)
        {
            var program = new Program()
            {
                Id = Guid.NewGuid(),
                Code = code,
                Title = title,
                Description = description,
                Degree = degree,
                CreatedAt = DateTime.UtcNow
            };

            return program;
        }
    }
}
