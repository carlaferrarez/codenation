using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models.Configurations
{
    public class AccelerationConfiguration : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> builder)
        {
            builder.HasKey(x => x.Challenge_id);
        }
    }
}
