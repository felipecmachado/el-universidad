using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.Programs;
using ElUniversidad.Domain.Programs.Enums;
using ElUniversidad.Domain.Students;
using ElUniversidad.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
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
                var program = Program.New("MEDI", "Medicina", "Aqui, você realiza atividades práticas em hospitais e Unidades Básicas de Saúde (UBS) desde os primeiros semestres. Por quê? A resposta é simples: porque o paciente é o elemento mais importante no seu aprendizado. \r\n\r\nO propósito é que você se torne, a partir da relação com as pessoas e da interação com casos reais, um médico(a) com perfil humanista, ou seja, um profissional sensível e capaz de auxiliar cada paciente da melhor forma, de forma empática.  ​​\r\n\r\nE não faltam locais de prática, professores qualificados, laboratórios de última geração e projetos promovidos pelo curso para que você seja protagonista do seu caminho na graduação em Medicina da Unisinos", DegreeType.Bachelors);

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
                    Course.New("Linguagem e Interação na Saúde", string.Empty, string.Empty, 8, 6.0f),
                    Course.New("Imunologia", string.Empty, string.Empty, 8, 6.0f),
                    Course.New("Microbiologia", string.Empty, string.Empty, 8, 6.0f),
                    Course.New("Fundamentos de Patologia", string.Empty, string.Empty, 8, 6.0f),
                    Course.New("Farmacologia Médica", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Tecnologia da Informação Aplicada à Medicina", string.Empty, string.Empty, 4, 6.0f),
                    Course.New("Patologia Clínica", string.Empty, string.Empty, 8, 6.0f)                    
                };

                dbContext.Set<Course>()
                    .AddRange(courses);

                dbContext.SaveChanges();

                var structure = ProgramStructure.New(program.Id, "MEDI - Estrutura Versão 2022");

                dbContext.Set<ProgramStructure>().Add(structure);

                dbContext.SaveChanges();

                dbContext.Set<AssignedCourse>().AddRange(courses.Select(x => AssignedCourse.New(structure.Id, x.Id)));

                var offer = Offer.New(program.Id, structure.Id, new DateOnly(2022, 11, 01), new DateOnly(2023, 02, 22), 795.50m, 50);

                dbContext.Set<Offer>().Add(offer);

                dbContext.SaveChanges();
            }
            #endregion

            #region Enfermagem
            {
                var program = Program.New("ENFE", "Enfermagem", "Graduação em Enfermagem", DegreeType.Bachelors);

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

            #region Biomedicina
            {
                var program = Program.New("BIOM", "Biomedicina", "Graduação em Biomedicina", DegreeType.Bachelors);

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

            #region Técnico em Enfermagem
            {
                var program = Program.New("TENF", "Técnico em Enfermagem", "Gradução Técnica em Enfermagem", DegreeType.Associate);

                dbContext.Set<Program>()
                    .Add(program);

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
