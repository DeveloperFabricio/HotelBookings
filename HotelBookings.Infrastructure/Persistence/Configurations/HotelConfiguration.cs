using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels"); 

            builder.HasKey(h => h.ID); 
            builder.Property(h => h.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
