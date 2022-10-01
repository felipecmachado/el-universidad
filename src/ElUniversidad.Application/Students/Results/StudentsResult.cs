namespace ElUniversidad.Application.Students.Results
{
    public class StudentsResult
    {
        public IList<StudentResult> Students { get; set; }

        public StudentsResult()
        {
            Students = new List<StudentResult>();
        }
    }

    public class StudentResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
}
