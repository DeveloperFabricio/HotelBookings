using HotelBookings.Application.DTO_s;
using HotelBookings.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Queries.ObterInformacoesPagamento
{
    public class ObterInformacoesPagamentoQueryHandler : IRequestHandler<ObterInformacoesPagamentoQuery, InformacoesPagamentoDTO>
    {
        private readonly IInformacoesDePagamentoRepository _informacoesPagamentoRepository;

        public ObterInformacoesPagamentoQueryHandler(IInformacoesDePagamentoRepository informacoesPagamentoRepository)
        {
            _informacoesPagamentoRepository = informacoesPagamentoRepository ?? throw new ArgumentNullException(nameof(informacoesPagamentoRepository));
        }

        public async Task<InformacoesPagamentoDTO> Handle(ObterInformacoesPagamentoQuery request, CancellationToken cancellationToken)
        {
            
            var informacoesPagamento = await _informacoesPagamentoRepository.ObterPorId(request.ReservaId);

            
            var informacoesPagamentoDTO = new InformacoesPagamentoDTO
            {
                Id = informacoesPagamento.ID,
                ReservaId = informacoesPagamento.IDDaReserva,
                MetodoPagamento = informacoesPagamento.MetodoDePagamento,
                ValorPago = informacoesPagamento.ValorPago,
                StatusPagamento = informacoesPagamento.StatusDoPagamento,
                DataHoraPagamento = informacoesPagamento.DataEHoraDoPagamento
            };

            return informacoesPagamentoDTO;
        }
    
    }
}
