using CurrencyExchange.Core.Enities;
using CurrencyExchange.Core.Interfaces;
using CurrencyExchange.Infrastructure.Data;
using CurrencyExchange.Infrastructure.Data.Repositories;
using CurrencyExchange.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddResponseCaching();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddInfrastructureServices(connectionString);
var app = builder.Build();

app.Services.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
