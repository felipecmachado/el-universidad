using ElUniversidad.Domain.Programs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElUniversidad.Infrastructure.Data.Mappings
{
    public class OfferMap : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.AdmissionsQuota)
                .IsRequired();

            builder.Property(x => x.PricePerCredit)
                .IsRequired();

            builder.Property(x => x.StartingOn)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.ToTable("Offers");

            builder.HasOne(x => x.Program)
                .WithMany(x => x.Offers);

            builder.HasOne(x => x.ProgramStructure)
                .WithMany(x => x.Offers);
        }
    }
}