using ElUniversidad.Domain.Programs;
using ElUniversidad.Domain.Programs.Enums;

namespace ElUniversidad.Infrastructure.Data.Seeders
{
    public static class ProgramsSeeder
    {
        public static IList<Program> SeedPrograms()
        {
            var programs = new List<Program>()
            {
                Program.New("FARM", "Farmácia", "Graduação em Farmácia", DegreeType.Undergraduate),
                Program.New("MEDI", "Medicina", "Graduação em Medicina", DegreeType.Undergraduate)
            };

            return programs;
        }
    }
}
