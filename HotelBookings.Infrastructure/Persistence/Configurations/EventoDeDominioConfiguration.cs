using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class EventoDeDominioConfiguration : IEntityTypeConfiguration<EventoDeDominio>
    {
        public void Configure(EntityTypeBuilder<EventoDeDominio> builder)
        {
            
            builder.ToTable("EventosDeDominio");
                        
            builder.HasKey(e => e.TipoDeEvento);
            builder.Property(e => e.TipoDeEvento).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DadosRelevantes).IsRequired();
            builder.Property(e => e.Timestamp).IsRequired();
        }
    }

}
