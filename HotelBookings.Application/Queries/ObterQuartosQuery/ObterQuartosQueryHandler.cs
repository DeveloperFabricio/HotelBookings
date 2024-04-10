using HotelBookings.Application.DTO_s;
using HotelBookings.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Queries.ObterQuartosQuery
{
    public class ObterQuartosQueryHandler : IRequestHandler<ObterQuartosQuery, IEnumerable<QuartoDTO>>
    {
        private readonly IQuartoRepository _quartoRepository;

        public ObterQuartosQueryHandler(IQuartoRepository quartoRepository)
        {
            _quartoRepository = quartoRepository;
        }

        public async Task<IEnumerable<QuartoDTO>> Handle(ObterQuartosQuery query, CancellationToken cancellationToken)
        {
            var quartosDisponiveis = await _quartoRepository.ObterQuartosDisponiveis();

            
            var quartosDto = quartosDisponiveis.Select(q => new QuartoDTO
            {
                
                Id = q.ID,
                
            });

            return quartosDto;
        }
    
    }
}
