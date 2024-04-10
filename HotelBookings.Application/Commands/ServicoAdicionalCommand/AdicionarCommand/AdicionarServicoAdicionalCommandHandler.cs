using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using HotelBookings.Core.Services.ServicoAdicionalService;
using MediatR;

namespace HotelBookings.Application.Commands.ServicoAdicionalCommand.AdicionarCommand
{
    public class AdicionarServicoAdicionalCommandHandler : IAdicionarServicoAdicionalCommandHandler
    {
        private readonly IServicoAdicionalRepository _servicoAdicionalRepository;
        private readonly IMediator _mediator;

        public AdicionarServicoAdicionalCommandHandler(IServicoAdicionalRepository servicoAdicionalRepository, IMediator mediator)
        {
            _servicoAdicionalRepository = servicoAdicionalRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(IAdicionarServicoAdicionalCommand request, CancellationToken cancellationToken)
        {
            
            var novoServicoAdicional = new ServicoAdicional
            {
                NomeDoServico = request.NomeDoServico,
                Descricao = request.Descricao,
                PrecoAdicional = request.PrecoAdicional
            };

            
            await _mediator.Send(novoServicoAdicional);

            return Unit.Value;
        }

    }
}
