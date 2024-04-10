namespace HotelBookings.Core.Services.ServicoAdicionalService
{
    public interface IAdicionarServicoAdicionalCommand
    {
         int ReservaId { get; }
         string NomeDoServico { get; }
         string Descricao { get; }
         decimal PrecoAdicional { get; }
    }
}
