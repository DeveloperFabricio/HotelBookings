using HotelBookings.Application.DTO_s;

namespace HotelBookings.Application.Services
{
    public interface IPagamentoServico
    {
        void ProcessandoPagamento(PagamentoClienteDTO pagamentoCliente);
    }
}
