using HotelBookings.Application.Commands.AvaliacaoClienteCommand;
using HotelBookings.Application.Commands.PagamentoClientCommand;
using HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CancelarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CriarReservaCommand;
using HotelBookings.Application.Commands.ServicoAdicionalCommand.AdicionarCommand;
using HotelBookings.Application.Queries.ObterInformacoesPagamento;
using HotelBookings.Application.Queries.ObterQuartosQuery;
using HotelBookings.Application.ViewModels;
using HotelBookings.Core.Interfaces;
using HotelBookings.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservaRepository _reservaRepository;
        private readonly IClienteRepository _clienteRepository;

        public HotelController( 
            IMediator mediator, 
            IUnitOfWork unitOfWork, 
            IReservaRepository reservaRepository,
            IClienteRepository clienteRepository)
        {
           
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _reservaRepository = reservaRepository;
            _clienteRepository = clienteRepository;
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
                var cliente = await _clienteRepository.ObterPorId(reservaRequest.ClienteId);
                var reserva = await _reservaRepository.ObterPorId(command.ReservaId);

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

        [HttpGet("reserva/{reservaId}/pagamento")]
        public async Task<IActionResult> ObterInformacoesPagamento(int reservaId)
        {
            var query = new ObterInformacoesPagamentoQuery { ReservaId = reservaId };
            var informacoesPagamento = await _mediator.Send(query);

            if (informacoesPagamento != null)
            {
                var viewModel = new InformacoesPagamentoViewModel
                {
                    Id = informacoesPagamento.Id,
                    IdReserva = informacoesPagamento.ReservaId,
                    MetodoPagamento = informacoesPagamento.MetodoPagamento,
                    ValorPago = informacoesPagamento.ValorPago,
                    StatusPagamento = informacoesPagamento.StatusPagamento,
                    DataHoraPagamento = informacoesPagamento.DataHoraPagamento
                };
                return Ok(viewModel);
            }
            else
            {
                return NotFound("Informações de pagamento não encontradas para a reserva especificada.");
            }
        }

        [HttpPut("{id}/pagamentos")]
        public async Task<IActionResult> PagamentoFinal(int id, PagamentoClienteCommand command)
        {
            command.Id = id;

            var resultado = await _mediator.Send(command);

            if (!resultado)
            {
                return BadRequest("O Pagamento não pode ser processado!");
            }

            return Accepted(resultado);
        }

        [HttpPost("avaliacao-cliente")]
        public async Task<IActionResult> AvaliarCliente(AvaliacaoClienteViewModel avaliacaoRequest)
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

            return Ok("Avaliação do cliente adicionada com sucesso!");
        }
    }
}