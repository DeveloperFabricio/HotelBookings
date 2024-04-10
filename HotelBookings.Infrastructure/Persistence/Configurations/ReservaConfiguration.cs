using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            
            builder.ToTable("Reservas");

            builder.HasKey(r => r.ID);
            builder.Property(r => r.IDDoCliente).IsRequired();
            builder.Property(r => r.IDDoQuarto).IsRequired();
            builder.Property(r => r.DataDeCheckIn).IsRequired();
            builder.Property(r => r.DataDeCheckOut).IsRequired();
            builder.Property(r => r.NumeroDeHospedes).IsRequired();
            builder.Property(r => r.StatusDaReserva).HasMaxLength(50).IsRequired();

           
            builder.HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteID)
                .IsRequired();

            
            builder.HasOne(r => r.Quarto)
                .WithMany(q => q.Reservas)
                .HasForeignKey(r => r.IDDoQuarto)
                .IsRequired();
        }
    }

}
