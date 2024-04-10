using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class InformacoesDePagamentoConfiguration : IEntityTypeConfiguration<InformacoesDePagamento>
    {
        public void Configure(EntityTypeBuilder<InformacoesDePagamento> builder)
        {
          
            builder.ToTable("InformacoesDePagamento");

            builder.HasKey(ip => ip.ID);
            builder.Property(ip => ip.IDDaReserva).IsRequired();
            builder.Property(ip => ip.MetodoDePagamento).IsRequired().HasMaxLength(100);
            builder.Property(ip => ip.ValorPago).IsRequired();
            builder.Property(ip => ip.StatusDoPagamento).IsRequired().HasMaxLength(50);
            builder.Property(ip => ip.DataEHoraDoPagamento).IsRequired();
        }
    }

}
