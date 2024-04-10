using HotelBookings.Core.Services;
using System.Text;
using System.Text.Json;

namespace HotelBookings.Infrastructure.Payments
{
    public class ServicoPagamento : IServicoPagamento
    {
        private readonly IServicoMensagem _servicoMensagem;
        private const string QUEUE_NOME = "Pagamentos";

        public ServicoPagamento(IServicoMensagem servicoMensagem)
        {
            _servicoMensagem = servicoMensagem;
        }

        public void PagamentoProcessado(IPagamentoInfo pagamentoInfo)
        {
            var pagamentoInfoJson = JsonSerializer.Serialize(pagamentoInfo);

            var pagamentoInfoBytes = Encoding.UTF8.GetBytes(pagamentoInfoJson);

            _servicoMensagem.Publicar(QUEUE_NOME, pagamentoInfoBytes);
        }
    }
}