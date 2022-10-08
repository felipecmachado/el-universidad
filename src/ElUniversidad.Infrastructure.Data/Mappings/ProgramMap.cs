using ElUniversidad.Domain.Programs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElUniversidad.Infrastructure.Data.Mappings
{
    public class ProgramMap : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.Degree)
                .IsRequired();

            builder.ToTable("Programs");
        }
    }
}