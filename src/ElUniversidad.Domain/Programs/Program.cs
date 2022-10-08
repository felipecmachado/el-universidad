using ElUniversidad.Domain.Programs.Enums;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Programs
{
    public class Program : Entity, IAggregateRoot
    {
        // References:
        // https://en.wikipedia.org/wiki/Undergraduate_education
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AdditionalInformation { get; private set; }
        public DegreeType Degree { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        public ICollection<ProgramStructure> ProgramStructures { get; set; } = new List<ProgramStructure>();
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();

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

        public void UpdateTitleAndDescription(string title, string description)
        {
            Title = title;
            Description = description;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
