using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class ServicoAdicionalConfiguration : IEntityTypeConfiguration<ServicoAdicional>
    {
        public void Configure(EntityTypeBuilder<ServicoAdicional> builder)
        {
           
            builder.ToTable("ServicosAdicionais");

            
            builder.HasKey(sa => sa.ID);
            builder.Property(sa => sa.NomeDoServico).HasMaxLength(100).IsRequired();
            builder.Property(sa => sa.Descricao).HasMaxLength(500);
            builder.Property(sa => sa.PrecoAdicional).HasColumnType("decimal(18,2)").IsRequired();
        }
    }

}
