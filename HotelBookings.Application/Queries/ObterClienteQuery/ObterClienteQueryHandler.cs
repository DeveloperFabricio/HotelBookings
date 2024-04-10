using HotelBookings.Application.DTO_s;
using HotelBookings.Core.Interfaces;
using MediatR;

namespace HotelBookings.Application.Queries.ObterClienteQuery
{
    public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, ClienteDTO>
    {
        private readonly IClienteRepository _clienteRepository;

        public ObterClienteQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> Handle(ObterClienteQuery query, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorId(query.ClienteId);

            
            var clienteDto = new ClienteDTO
            {
                Id = cliente.ID,
                
            };

            return clienteDto;
        }
    
    }
}
