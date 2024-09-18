using AutoMapper;
using LoremIpsumLogistica.Application.Mappers;
using LoremIpsumLogistica.Application.Services.Implementations;
using LoremIpsumLogistica.Application.Services.Interfaces;
using LoremIpsumLogistica.Core.Interfaces;
using LoremIpsumLogistica.Infrastructure.Context;
using LoremIpsumLogistica.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conex�o do banco de dados
builder.Services.AddDbContext<LoremIpsumLogisticaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoremIpsumLogisticaConnectionString")));

// Adicionar os reposit�rios e servi�os
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();
builder.Services.AddScoped<IClientsService, ClientsService>();

// Configurar o AutoMapper
var config = new MapperConfiguration(mp => { mp.AddProfile(new MappingProfile()); });
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

// Adicionar controladores
builder.Services.AddControllers();

// Configurar a documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de solicita��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
