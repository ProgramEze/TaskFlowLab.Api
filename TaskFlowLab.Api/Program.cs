using TaskFlowLab.Application.Integrations;
using TaskFlowLab.Application.Interfaces;
using TaskFlowLab.Application.Servicios;
using TaskFlowLab.Domain.Entities;
using TaskFlowLab.Domain.Enums;
using TaskFlowLab.Infrastructure.Integrations;
using TaskFlowLab.Infrastructure.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ITareaRepositorio como Singleton: el diccionario en memoria debe sobrevivir entre requests
builder.Services.AddSingleton<ITareaRepositorio, TareaRepositorio>();
builder.Services.AddScoped<ITareaServicio, TareaServicio>();

// Integracion Workspace: Null Object hasta que se configuren credenciales reales
builder.Services.AddScoped<IServicioAutomatizacionWorkspace, NullServicioAutomatizacionWorkspace>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

// Seed de datos para prueba manual
var repositorio = app.Services.GetRequiredService<ITareaRepositorio>();

await repositorio.AgregarAsync(new Tarea(
    Guid.Parse("00000000-0000-0000-0000-000000000001"),
    "Preparar informe mensual",
    EstadoTarea.Pendiente,
    DateTime.UtcNow.AddDays(-1)));  // vencida ayer → completarla debe dar 400

await repositorio.AgregarAsync(new Tarea(
    Guid.Parse("00000000-0000-0000-0000-000000000002"),
    "Revisar código del módulo usuarios",
    EstadoTarea.EnProgreso,
    DateTime.UtcNow.AddDays(1)));   // vence mañana → se puede completar

await repositorio.AgregarAsync(new Tarea(
    Guid.Parse("00000000-0000-0000-0000-000000000003"),
    "Actualizar documentación",
    EstadoTarea.Pendiente,
    null));                          // sin vencimiento → siempre se puede completar

app.Run();
