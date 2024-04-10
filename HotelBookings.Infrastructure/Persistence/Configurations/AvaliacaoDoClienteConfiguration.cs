using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class AvaliacaoDoClienteConfiguration : IEntityTypeConfiguration<AvaliacaoDoCliente>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoDoCliente> builder)
        {
            
            builder.ToTable("AvaliacoesDoCliente");

            
            builder.HasKey(a => a.ID);

            
            builder.Property(a => a.IDDoCliente)
                   .IsRequired();

            
            builder.Property(a => a.IDDoHotel)
                   .IsRequired();

            
            builder.Property(a => a.Classificacao)
                   .IsRequired();

           
            builder.Property(a => a.Comentario)
                   .HasMaxLength(500); 

            
            builder.Property(a => a.DataDaAvaliacao)
                   .IsRequired();
        }
               
    }    
}
