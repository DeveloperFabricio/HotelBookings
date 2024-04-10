using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class QuartoConfiguration : IEntityTypeConfiguration<Quarto>
    {
        public void Configure(EntityTypeBuilder<Quarto> builder)
        {
            
            builder.ToTable("Quartos");

            builder.HasKey(q => q.ID);
            builder.Property(q => q.NumeroDoQuarto).IsRequired().HasMaxLength(50);
            builder.Property(q => q.TipoDeQuarto).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Descricao).HasMaxLength(255);
            builder.Property(q => q.PrecoPorNoite).IsRequired();
            builder.Property(q => q.Disponivel).IsRequired();

            builder.HasMany(q => q.Reservas)
                .WithOne(r => r.Quarto)
                .HasForeignKey(r => r.IDDoQuarto)
                .IsRequired();
        }
    }

}
