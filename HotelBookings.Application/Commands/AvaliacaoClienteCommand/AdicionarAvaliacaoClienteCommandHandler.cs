using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using HotelBookings.Core.Services.AvaliacaoClienteService;
using MediatR;

namespace HotelBookings.Application.Commands.AvaliacaoClienteCommand
{
    public class AdicionarAvaliacaoClienteCommandHandler : IAdicionarAvaliacaoClienteCommandHandler
    {
        private readonly IAvaliacaoDoClienteRepository _avaliacaoRepository;
        private readonly IMediator _mediator;

        public AdicionarAvaliacaoClienteCommandHandler(IAvaliacaoDoClienteRepository avaliacaoRepository, IMediator mediator)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(IAdicionarAvaliacaoClienteCommand request, CancellationToken cancellationToken)
        {
            var novaAvaliacao = new AvaliacaoDoCliente
            {
                IDDoCliente = request.IDDoCliente,
                IDDoHotel = request.IDDoHotel,
                Classificacao = request.Classificacao,
                Comentario = request.Comentario,
                DataDaAvaliacao = request.DataDaAvaliacao
            };

            await _avaliacaoRepository.Adicionar(novaAvaliacao);
            await _mediator.Send(request);

            return Unit.Value;
        }
    }
}
