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
        public string Code { get; set; }
        public int Title { get; set; }
    }
}
