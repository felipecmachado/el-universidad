using ElUniversidad.Domain.Programs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElUniversidad.Infrastructure.Data.Mappings
{
    public class ProgramStructureMap : IEntityTypeConfiguration<ProgramStructure>
    {
        public void Configure(EntityTypeBuilder<ProgramStructure> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasOne(x => x.Program)
                .WithMany(x => x.ProgramStructures);

            builder.ToTable("ProgramStructures");
        }
    }
}