using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Domain.Programs
{
    public class Offer : Entity
    {
        public Guid Id { get; private set; }
        public Guid ProgramId { get; private set; }
        public Guid ProgramStructureId { get; private set; }

        public DateOnly AdmissionAvailableUntil { get; private set; }
        public DateOnly StartingOn { get; private set; }

        public decimal PricePerCredit { get; private set; }
        public int AdmissionsQuota { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        public virtual Program Program { get; set; }
        public virtual ProgramStructure ProgramStructure { get; set; }

        public static Offer New(
            Guid programId, 
            Guid programStructureId, 
            DateOnly admissionAvailableUntil, 
            DateOnly startingOn, 
            decimal pricePerCredit,
            int admissionsQuota)
        {
            return new Offer()
            {
                Id = Guid.NewGuid(),
                ProgramId = programId,
                ProgramStructureId = programStructureId,
                AdmissionAvailableUntil = admissionAvailableUntil,
                StartingOn = startingOn,
                PricePerCredit = pricePerCredit,
                AdmissionsQuota = admissionsQuota,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
