using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarWashAggregator.Review.Infra.ConfigEntity
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Entities.Review>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Entities.Review> builder)
        {
	        builder.ToTable("Review");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Body).IsRequired();

            builder.Property(x => x.Rating).IsRequired();
            
            builder.Property(x => x.UserId).IsRequired();
            
            builder.Property(x => x.carWashId).IsRequired();
            

        }
    }
}
