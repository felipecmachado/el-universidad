namespace ElUniversidad.Application.Programs.Results
{
    public class ProgramsResult
    {
        public IList<ProgramResult> Programs { get; set; }

        public ProgramsResult()
        {
            Programs = new List<ProgramResult>();
        }
    }

    public class ProgramResult
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    }
}
