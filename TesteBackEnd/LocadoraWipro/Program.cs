using LocadoraWipro.Data;
using LocadoraWipro.Services;
using LocadoraWipro.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; 


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LocadoraContext>(context => context.UseSqlite(configuration.GetConnectionString("Sqlite")));
builder.Services.AddTransient<IFilmeService, FilmeService>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<ILocacaoService, LocacaoService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
