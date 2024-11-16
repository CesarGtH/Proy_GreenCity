using Microsoft.EntityFrameworkCore;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using Proy_GreenCity.DOMAIN.Core.Services;
using Proy_GreenCity.DOMAIN.Infraestructure.Data;
using Proy_GreenCity.DOMAIN.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<GreenCityContext>
    (options => options.UseSqlServer(cnx));

builder.Services.AddTransient<IComentariosRepository, ComentariosRepository>();
builder.Services.AddTransient<IEstadoReportesRepository, EstadoReportesRepository>();
builder.Services.AddTransient<IEstadoReportesService, EstadoReportesService>();
builder.Services.AddTransient<INotificacionesRepository, NotificacionesRepository>();
builder.Services.AddTransient<IReportesRepository, ReportesRepository>();
builder.Services.AddTransient<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddControllers();


//ADD CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder//.WithOrigins("http://www.midominiofrontend.com")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
