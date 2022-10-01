using ElUniversidad.Domain.Programs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElUniversidad.Infrastructure.Data.Mappings
{
    public class CourseStructureMap : IEntityTypeConfiguration<CourseStructure>
    {
        public void Configure(EntityTypeBuilder<CourseStructure> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasOne<Program>()
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(i => i.ProgramId);

            builder.ToTable("CourseStructures");
        }
    }
}