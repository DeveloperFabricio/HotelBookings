using FluentValidation;
using HotelBookings.Application.Commands.AvaliacaoClienteCommand;
using HotelBookings.Application.Commands.PagamentoClientCommand;
using HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CancelarReservaCommand;
using HotelBookings.Application.Commands.ReservaCommand.CriarReservaCommand;
using HotelBookings.Application.Commands.ServicoAdicionalCommand.AdicionarCommand;
using HotelBookings.Application.Consumers;
using HotelBookings.Application.DTO_s;
using HotelBookings.Application.Email;
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
using HotelBookings.Core.IntegrationEvents;
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
using HotelBookingsAPI.Filters;
using HotelBookingsAPI.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string chaveSecreta = "ae452bfe-50c2-4291-bcf9-a63d96838ed9";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HotelBookings - API", Version = "v1" });

    var securitySchems = new OpenApiSecurityScheme
    {
        Name = "JWT Autenticação",
        Description = "Entre com o JWT Bearer Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchems);
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securitySchems, new string[] { } }
            });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "HotelBookings",
        ValidAudience = "HotelBookings",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
    };
});

builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IQuartoRepository, QuartoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IServicoAdicionalRepository, ServicoAdicionalRepository>();
builder.Services.AddScoped<IAvaliacaoDoClienteRepository, AvaliacaoDoClienteRepository>();
builder.Services.AddScoped<IInformacoesDePagamentoRepository, InformacoesDePagamentoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServicoMensagem, ServicoMensagem>();
builder.Services.AddScoped<IServicoPagamento, ServicoPagamento>();
builder.Services.AddScoped<IServicoReserva, ServicoReserva>();
builder.Services.AddScoped<IReservaService, ReservaService>(); 
builder.Services.AddScoped<IPagamentoServico, MockPagamentoServico>();
builder.Services.AddScoped<IEmailServico, EmailServico>();


builder.Services.AddScoped<IRequestHandler<ObterQuartosQuery, IEnumerable<QuartoDTO>>, ObterQuartosQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ObterReservasQuery, IEnumerable<ReservaDTO>>, ObterReservasQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ObterClienteQuery, ClienteDTO>, ObterClienteQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ObterInformacoesPagamentoQuery, InformacoesPagamentoDTO>, ObterInformacoesPagamentoQueryHandler>();

builder.Services.AddScoped<ICriarReservaCommandHandler, CriarReservaCommandHandler>();
builder.Services.AddScoped<IAtualizarReservaCommandHandler, AtualizarReservaCommandHandler>();
builder.Services.AddScoped<ICancelarReservaCommandHandler, CancelarReservaCommandHandler>();
builder.Services.AddScoped<IAdicionarServicoAdicionalCommandHandler, AdicionarServicoAdicionalCommandHandler>();
builder.Services.AddScoped<IAdicionarAvaliacaoClienteCommandHandler, AdicionarAvaliacaoClienteCommandHandler>();
builder.Services.AddScoped<IPagamentoClienteCommandHandler, PagamentoClienteCommandHandler>();

builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(AdicionarAvaliacaoClienteCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(PagamentoClienteCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(AtualizarReservaCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CancelarReservaCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CriarReservaCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(AdicionarServicoAdicionalCommand)));

builder.Services.AddTransient<IValidator<AvaliacaoClienteInputModel>, AvaliacaoClienteInputModelValidator>();
builder.Services.AddTransient<IValidator<ClienteInputModel>, ClienteInputModelValidator>();
builder.Services.AddTransient<IValidator<InformacoesPagamentoInputModel>, InformacoesPagamentoInputModelValidator>();
builder.Services.AddTransient<IValidator<ReservaInputModel>, ReservaInputModelValidator>();


builder.Services.AddScoped<QuartoDTO>();
builder.Services.AddScoped<ReservaDTO>();
builder.Services.AddScoped<ClienteDTO>();
builder.Services.AddScoped<InformacoesPagamentoDTO>();
builder.Services.AddScoped<AvaliacaoClienteDTO>();
builder.Services.AddScoped<PagamentoClienteDTO>();

builder.Services.AddSingleton<AvaliacaoClienteViewModel>();
builder.Services.AddSingleton<ClienteViewModel>();
builder.Services.AddSingleton<InformacoesPagamentoViewModel>();
builder.Services.AddSingleton<QuartoViewModel>();
builder.Services.AddSingleton<ReservaViewModel>();
builder.Services.AddSingleton<ServicoAdicionalViewModel>();

builder.Services.AddSingleton<AvaliacaoClienteInputModel>();
builder.Services.AddSingleton<ClienteInputModel>();
builder.Services.AddSingleton<InformacoesPagamentoInputModel>();
builder.Services.AddSingleton<ReservaInputModel>();

builder.Services.AddHostedService<PagamentoAprovado>();
builder.Services.AddHostedService<ConsumidorReservaConfirmada>();

builder.Services.AddHttpClient();

builder.Services.Configure<WebMailOptions>(builder.Configuration.GetSection("WebMailOptions"));
builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMqOptions"));


builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidationFilter));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelBookings.API v1"));
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


