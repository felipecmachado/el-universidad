using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.Programs;
using ElUniversidad.Domain.Programs.Enums;
using ElUniversidad.Domain.Students;
using ElUniversidad.Infrastructure.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace ElUniversidad.Infrastructure.Data.Seeders
{
    public static class DatabaseSeeder
    {
        public static void SeedData(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetService<ElUniversidadContext>();

            if (dbContext is null)
            {
                throw new ArgumentException(nameof(dbContext));
            }

            #region Farmácia
            {
                var program = Program.New("FARM", "Farmácia", "Graduação em Farmácia", DegreeType.Bachelors);

                dbContext.Set<Program>()
                    .Add(program);

                dbContext.SaveChanges();

                var courses = new List<Course>()
                {
                    Course.New("Introdução às Ciências Farmacêuticas", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Práticas em Anatomia Humana", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Práticas em Fisiologia Humana", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Saúde Coletiva", string.Empty, string.Empty, 8, 6.0f),
                    Course.New("Estatística Aplicada à Saúde ", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Laboratório Clínico", string.Empty, string.Empty, 8, 6.0f)
                };

                dbContext.Set<Course>()
                    .AddRange(courses);

                dbContext.SaveChanges();
            }
            #endregion

            #region Medicina
            {
                var program = Program.New("MEDI", "Medicina", "Graduação em Medicina", DegreeType.Bachelors);

                dbContext.Set<Program>()
                    .Add(program);

                dbContext.SaveChanges();

                var courses = new List<Course>()
                {
                    Course.New("Anatomia Humana", string.Empty, string.Empty, 8, 6.0f),
                    Course.New("Ciências Sociais Aplicadas à Saúde", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Bioquímica", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Fisiologia Médica e Biofísica", string.Empty, string.Empty, 8, 6.0f),
                    Course.New("Genética", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Linguagem e Interação na Saúde", string.Empty, string.Empty, 8, 6.0f)
                };

                dbContext.Set<Course>()
                    .AddRange(courses);

                dbContext.SaveChanges();
            }
            #endregion

            #region Students
            {
                var students = new List<Student>()
                {
                    Student.New("Aluno", "A", new DateOnly(1990,03,01)),
                    Student.New("Aluno", "B", new DateOnly(1991,04,02)),
                    Student.New("Aluno", "C", new DateOnly(1992,05,03)),
                    Student.New("Aluno", "D", new DateOnly(1993,06,04)),
                    Student.New("Aluno", "E", new DateOnly(1994,07,05))
                };

                dbContext.Set<Student>()
                    .AddRange(students);

                dbContext.SaveChanges();
            }
            #endregion
        }
    }
}
