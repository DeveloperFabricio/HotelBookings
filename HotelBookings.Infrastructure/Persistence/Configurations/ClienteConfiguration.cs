using HotelBookings.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            
            builder.ToTable("Clientes");

            
            builder.HasKey(c => c.ID);

            
            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Telefone)
                   .HasMaxLength(20);

           
            builder.HasMany(c => c.Reservas)
                   .WithOne(r => r.Cliente)
                   .HasForeignKey(r => r.ClienteID);
        }
    }

}
