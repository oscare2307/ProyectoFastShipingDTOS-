using Pedidos.Context;
using Microsoft.EntityFrameworkCore;
using Pedidos.Mapeos;

var builder = WebApplication.CreateBuilder(args);


var connection = builder.Configuration.GetConnectionString("connectionWindows");

//Inyección de Dependencias

builder.Services.AddDbContext<DbContexto>(opt => opt.UseSqlServer(connection));
builder.Services.AddAutoMapper(typeof(AutoMaperPerfil));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
