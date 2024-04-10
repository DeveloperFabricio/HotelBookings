using HotelBookings.Core.Entities;
using HotelBookings.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EventoDeDominio> EventosDeDominio { get; set; }
        public DbSet<ServicoAdicional> ServicosAdicionais { get; set; }
        public DbSet<AvaliacaoDoCliente> AvaliacoesDosClientes { get; set; }
        public DbSet<InformacoesDePagamento> InformacoesDePagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new HotelConfiguration());

            modelBuilder.ApplyConfiguration(new AvaliacaoDoClienteConfiguration());

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            modelBuilder.ApplyConfiguration(new EventoDeDominioConfiguration());

            modelBuilder.ApplyConfiguration(new QuartoConfiguration());

            modelBuilder.ApplyConfiguration(new InformacoesDePagamentoConfiguration());

            modelBuilder.ApplyConfiguration(new ReservaConfiguration());

            modelBuilder.ApplyConfiguration(new ServicoAdicionalConfiguration());


        }
    }
}
