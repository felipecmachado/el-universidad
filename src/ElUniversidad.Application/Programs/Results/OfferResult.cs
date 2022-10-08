namespace ElUniversidad.Application.Programs.Results
{
    public class OffersResult
    {
        public IList<OfferResult> Offers { get; set; }

        public OffersResult()
        {
            Offers = new List<OfferResult>();
        }
    }

    public class OfferResult
    {
        public Guid Id { get; set; }
        public DateOnly AdmissionAvailableUntil { get; set; }
        public DateOnly StartingOn { get; set; }
        public decimal PricePerCredit { get; set; }
        public int AdmissionsQuota { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProgramStructureResult ProgramStructure { get; set; }
    }
}
