using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.Programs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElUniversidad.Infrastructure.Data.Mappings
{
    public class AssignedCourseMap : IEntityTypeConfiguration<AssignedCourse>
    {
        public void Configure(EntityTypeBuilder<AssignedCourse> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties

            builder.ToTable("AssignedCourses");
        }
    }
}