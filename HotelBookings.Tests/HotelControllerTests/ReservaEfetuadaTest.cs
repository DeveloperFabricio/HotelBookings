using HotelBookings.Application.Commands.ReservaCommand.CriarReservaCommand;
using HotelBookings.Core.Interfaces;
using HotelBookings.Infrastructure.Persistence;
using HotelBookingsAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotelBookings.Tests.HotelControllerTests
{
    public class ReservaEfetuadaTest
    {
        [Fact]
        public async Task ReservarQuarto_Deve_Retornar_ReservaEfetuadaComSucesso()
        {
           
            var clienteId = 1;
            var quartoId = 1;
            var dataCheckIn = new DateTime(2024, 04, 10);
            var dataCheckOut = new DateTime(2024, 04, 12);
            var numeroHospedes = 2;

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            
            var mockMediator = new Mock<IMediator>();
            var mockReservaRepository = new Mock<IReservaRepository>();
            var mockClienteRepository = new Mock<IClienteRepository>();

            var hotelController = new HotelController(
                                                       mockMediator.Object,
                                                       mockUnitOfWork.Object,
                                                       mockReservaRepository.Object,
                                                       mockClienteRepository.Object);

            var reservaRequest = new CriarReservaCommand
            {
                ClienteId = clienteId,
                QuartoId = quartoId,
                DataCheckIn = dataCheckIn,
                DataCheckOut = dataCheckOut,
                NumeroHospedes = numeroHospedes
            };

           
            var result = await hotelController.ReservarQuarto(reservaRequest);

           
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Reserva efetuada com sucesso!", okResult.Value);
        }

    }
}
