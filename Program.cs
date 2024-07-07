using Microsoft.EntityFrameworkCore;
using TareasAPI_902.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

/* SE OBTIENE LA CADENA DE CONEXCION */
var cadenaConexion = builder.Configuration.GetConnectionString("bd_tareas");

/* CONFIGURAMOS SERVICIO PARA USAR SQL SERVER */
builder.Services.AddDbContext<BdTareas902Context>(options =>
options.UseSqlServer(cadenaConexion));

/* CONFIGURACION DEL CORS */
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Activamos la nueva politica CORS
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
