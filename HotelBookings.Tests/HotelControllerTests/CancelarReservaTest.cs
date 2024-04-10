using HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand;
using HotelBookings.Core.Interfaces;
using HotelBookings.Infrastructure.Persistence;
using HotelBookingsAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotelBookings.Tests.HotelControllerTests
{
    public class CancelarReservaTest
    {
        [Fact]
        public async Task CancelarReserva_Deve_Retornar_ReservaCanceladaComSucesso()
        {
            
            var reservaId = 1;

            var atualizacaoRequest = new AtualizarReservaCommand { };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockMediator = new Mock<IMediator>();
            var mockReservaRepository = new Mock<IReservaRepository>();
            var mockClienteRepository = new Mock<IClienteRepository>();

            var hotelController = new HotelController(
                                                       mockMediator.Object,
                                                       mockUnitOfWork.Object,
                                                       mockReservaRepository.Object,
                                                       mockClienteRepository.Object);


            var result = await hotelController.CancelarReserva(reservaId);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Reserva cancelada com sucesso!", okResult.Value);
        }
    }
}
