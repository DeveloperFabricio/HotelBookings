using HotelBookings.Application.DTO_s;
using HotelBookings.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Queries.ObterReservasQuery
{
    public class ObterReservasQueryHandler : IRequestHandler<ObterReservasQuery, IEnumerable<ReservaDTO>>
    {
        private readonly IReservaRepository _reservaRepository;

        public ObterReservasQueryHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<ReservaDTO>> Handle(ObterReservasQuery query, CancellationToken cancellationToken)
        {
            var reservas = await _reservaRepository.ObterTodos();

            
            var reservasDto = reservas.Select(r => new ReservaDTO
            {
                
                Id = r.ID,
                
            });

            return reservasDto;
        }
    
    }
}
