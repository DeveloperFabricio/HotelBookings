using HotelBookings.Application.DTO_s;
using HotelBookings.Application.Services;
using HotelBookings.Core.Interfaces;
using HotelBookings.Core.Services.PagamentoClienteService;
using MediatR;

namespace HotelBookings.Application.Commands.PagamentoClientCommand
{
    public class PagamentoClienteCommandHandler : IPagamentoClienteCommandHandler
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPagamentoServico _pagamentoServico;
       

        public PagamentoClienteCommandHandler(IClienteRepository clienteRepository, IPagamentoServico pagamentoServico)
        {
            _clienteRepository = clienteRepository;
           
            _pagamentoServico = pagamentoServico;
        }

        public async Task<bool> Handle(IPagamentoClienteCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _clienteRepository.ObterPorId(request.Id);

            decimal quantia = 0.0m;

            var pagamentoInfoDTO = new PagamentoClienteDTO(request.Id, request.CartaoCredito, request.Cvv, request.Expira, request.NomeCompleto, quantia);

            _pagamentoServico.ProcessandoPagamento(pagamentoInfoDTO);

            await _clienteRepository.SaveChangesAsync();

            return true;
        }

    }
}
