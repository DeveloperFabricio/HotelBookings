using HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand;
using HotelBookings.Core.Interfaces;
using HotelBookings.Infrastructure.Persistence;
using HotelBookingsAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotelBookings.Tests.HotelControllerTests
{
    public class AtualizarReservaTest
    {
        [Fact]
        public async Task AtualizarReserva_Deve_Retornar_ReservaAtualizadaComSucesso()
        {
           
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

            
            var result = await hotelController.AtualizarReserva(atualizacaoRequest);

           
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Reserva atualizada com sucesso!", okResult.Value);
        }
    }
}
