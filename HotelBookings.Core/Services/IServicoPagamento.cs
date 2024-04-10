namespace HotelBookings.Core.Services
{
    public interface IServicoPagamento
    {
        void PagamentoProcessado(IPagamentoInfo pagamentoInfo);
    }
}
