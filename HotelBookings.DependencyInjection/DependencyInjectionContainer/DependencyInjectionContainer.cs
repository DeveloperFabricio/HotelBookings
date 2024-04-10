using FluentValidation;
using HotelBookings.Application.Commands.AvaliacaoClienteCommand;
using HotelBookings.Application.Commands.PagamentoClientCommand;
using HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CancelarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CriarReservaCommand;
using HotelBookings.Application.Commands.ServicoAdicionalCommand.AdicionarCommand;
using HotelBookings.Application.Consumers;
using HotelBookings.Application.DTO_s;
using HotelBookings.Application.Mock;
using HotelBookings.Application.Models.InputModels;
using HotelBookings.Application.Options;
using HotelBookings.Application.Queries.ObterClienteQuery;
using HotelBookings.Application.Queries.ObterInformacoesPagamento;
using HotelBookings.Application.Queries.ObterQuartosQuery;
using HotelBookings.Application.Queries.ObterReservasQuery;
using HotelBookings.Application.Services;
using HotelBookings.Application.Validators;
using HotelBookings.Application.ViewModels;
using HotelBookings.Core.Interfaces;
using HotelBookings.Core.Services;
using HotelBookings.Core.Services.AvaliacaoClienteService;
using HotelBookings.Core.Services.PagamentoClienteService;
using HotelBookings.Core.Services.ReservaService.AtualizarReservaService;
using HotelBookings.Core.Services.ReservaService.CancelarReservaService;
using HotelBookings.Core.Services.ReservaService.CriarReservaService;
using HotelBookings.Core.Services.ServicoAdicionalService;
using HotelBookings.Infrastructure.MessageService;
using HotelBookings.Infrastructure.Payments;
using HotelBookings.Infrastructure.Persistence;
using HotelBookings.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace HotelBookings.DependencyInjection.DependencyInjectionContainer
{
    public static class DependencyInjectionContainer
    {
               
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IQuartoRepository, QuartoRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IServicoAdicionalRepository, ServicoAdicionalRepository>();
            services.AddScoped<IAvaliacaoDoClienteRepository, AvaliacaoDoClienteRepository>();
            services.AddScoped<IInformacoesDePagamentoRepository, InformacoesDePagamentoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServicoMensagem, ServicoMensagem>();
            services.AddScoped<IServicoPagamento, ServicoPagamento>();
            services.AddScoped<IServicoReserva, ServicoReserva>();
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<IPagamentoServico, MockPagamentoServico>();


            services.AddScoped<IRequestHandler<ObterQuartosQuery, IEnumerable<QuartoDTO>>, ObterQuartosQueryHandler>();
            services.AddScoped<IRequestHandler<ObterReservasQuery, IEnumerable<ReservaDTO>>, ObterReservasQueryHandler>();
            services.AddScoped<IRequestHandler<ObterClienteQuery, ClienteDTO>, ObterClienteQueryHandler>();
            services.AddScoped<IRequestHandler<ObterInformacoesPagamentoQuery, InformacoesPagamentoDTO>, ObterInformacoesPagamentoQueryHandler>();

            services.AddScoped<ICriarReservaCommandHandler, CriarReservaCommandHandler>();
            services.AddScoped<IAtualizarReservaCommandHandler, AtualizarReservaCommandHandler>();
            services.AddScoped<ICancelarReservaCommandHandler, CancelarReservaCommandHandler>();
            services.AddScoped<IAdicionarServicoAdicionalCommandHandler, AdicionarServicoAdicionalCommandHandler>();
            services.AddScoped<IAdicionarAvaliacaoClienteCommandHandler, AdicionarAvaliacaoClienteCommandHandler>();
            services.AddScoped<IPagamentoClienteCommandHandler, PagamentoClienteCommandHandler>();

            services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(AdicionarAvaliacaoClienteCommand)));
            services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(PagamentoClienteCommand)));
            services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(AtualizarReservaCommand)));
            services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CancelarReservaCommand)));
            services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CriarReservaCommand)));
            services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(AdicionarServicoAdicionalCommand)));

            services.AddTransient<IValidator<AvaliacaoClienteInputModel>, AvaliacaoClienteInputModelValidator>();
            services.AddTransient<IValidator<ClienteInputModel>, ClienteInputModelValidator>();
            services.AddTransient<IValidator<InformacoesPagamentoInputModel>, InformacoesPagamentoInputModelValidator>();
            services.AddTransient<IValidator<ReservaInputModel>, ReservaInputModelValidator>();


            services.AddScoped<QuartoDTO>();
            services.AddScoped<ReservaDTO>();
            services.AddScoped<ClienteDTO>();
            services.AddScoped<InformacoesPagamentoDTO>();
            services.AddScoped<AvaliacaoClienteDTO>();
            services.AddScoped<PagamentoClienteDTO>();

            services.AddSingleton<AvaliacaoClienteViewModel>();
            services.AddSingleton<ClienteViewModel>();
            services.AddSingleton<InformacoesPagamentoViewModel>();
            services.AddSingleton<QuartoViewModel>();
            services.AddSingleton<ReservaViewModel>();
            services.AddSingleton<ServicoAdicionalViewModel>();

            services.AddSingleton<AvaliacaoClienteInputModel>();
            services.AddSingleton<ClienteInputModel>();
            services.AddSingleton<InformacoesPagamentoInputModel>();
            services.AddSingleton<ReservaInputModel>();

            
            services.AddHostedService<PagamentoAprovado>();
            services.AddHostedService<ConsumidorReservaConfirmada>();

            
            
            return services;
        }

        
    }

}

