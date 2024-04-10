using HotelBookings.Application.Commands.AvaliacaoClienteCommand;
using HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CancelarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CriarReservaCommand;
using HotelBookings.Application.Commands.ServicoAdicionalCommand.AdicionarCommand;
using HotelBookings.Application.Queries.ObterQuartosQuery;
using HotelBookings.Application.ViewModels;
using HotelBookings.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
       

        public ClienteController(IMediator mediator, IUnitOfWork unitOfWork)
        {
           
            _mediator = mediator;
            _unitOfWork = unitOfWork;
           
        }

        [HttpGet("quartos")]
        public async Task<IActionResult> QuartosDisponiveis()
        {
            var query = new ObterQuartosQuery();
            var quartosDisponiveis = await _mediator.Send(query);
            return Ok(quartosDisponiveis);
        }

        [HttpPost("reservar-quarto")]
        public async Task<IActionResult> ReservarQuarto(CriarReservaCommand reservaRequest)
        {
            var command = new CriarReservaCommand
            {
                ClienteId = reservaRequest.ClienteId,
                QuartoId = reservaRequest.QuartoId,
                DataCheckIn = reservaRequest.DataCheckIn,
                DataCheckOut = reservaRequest.DataCheckOut,
                NumeroHospedes = reservaRequest.NumeroHospedes
            };

            await _mediator.Send(command);

            if (await _unitOfWork.Sucesso())
            {
                return Ok("Reserva efetuada com sucesso!");
            }
            else
            {
                return BadRequest(await _unitOfWork.MensagemErro());
            }
        }

        [HttpPut("atualizar-quarto")]
        public async Task<IActionResult> AtualizarReserva(AtualizarReservaCommand atualizacaoRequest)
        {
            var command = new AtualizarReservaCommand
            {
                ClienteId = atualizacaoRequest.ClienteId,
                QuartoId = atualizacaoRequest.QuartoId,
                DataCheckIn = atualizacaoRequest.DataCheckIn,
                DataCheckOut = atualizacaoRequest.DataCheckOut,
                NumeroHospedes = atualizacaoRequest.NumeroHospedes
            };

            await _mediator.Send(command);

            if (await _unitOfWork.Sucesso())
            {
                return Ok("Reserva atualizada com sucesso!");
            }
            else
            {
                return BadRequest(await _unitOfWork.MensagemErro());
            }
        }

        [HttpDelete("cancelar-reserva")]
        public async Task<IActionResult> CancelarReserva(int reservaId)
        {
            var command = new CancelarReservaCommand
            {
                ReservaId = reservaId
            };

            await _mediator.Send(command);

            if (await _unitOfWork.Sucesso())
            {
                return Ok("Reserva cancelada com sucesso!");
            }
            else
            {
                return BadRequest(await _unitOfWork.MensagemErro());
            }
        }

        [HttpPost("reserva/{reservaId}/servico-adicional")]
        public async Task<IActionResult> AdicionarServicoAdicional(int reservaId, AdicionarServicoAdicionalCommand comando)
        {
            comando.ReservaId = reservaId;
            var resultado = await _mediator.Send(comando);
            if (await _unitOfWork.Sucesso())
            {
                return Ok("Serviço adicional adicionado com sucesso!");
            }
            else
            {
                return BadRequest(await _unitOfWork.MensagemErro());
            }
        }

        [HttpPost("avaliacao-hotel")]
        public async Task<IActionResult> AvaliarHotel(AvaliacaoClienteViewModel avaliacaoRequest)
        {
            var command = new AdicionarAvaliacaoClienteCommand
            {
                IDDoCliente = avaliacaoRequest.IdCliente,
                IDDoHotel = avaliacaoRequest.IdHotel,
                Classificacao = avaliacaoRequest.Classificacao,
                Comentario = avaliacaoRequest.Comentario,
                DataDaAvaliacao = avaliacaoRequest.DataAvaliacao
            };

            await _mediator.Send(command);

            return Ok("Sua avaliação foi adicionada com sucesso!");
        }
    }
}
