using Microsoft.AspNetCore.Mvc;
using TaskFlowLab.Application.DTOs.EventosIntegracion;
using TaskFlowLab.Application.Servicios;

namespace TaskFlowLab.Api.Controllers;

[ApiController]
[Route("api/eventos-integracion")]
public class EventosIntegracionController : ControllerBase
{
    private readonly ServicioEventoIntegracion _servicio;

    public EventosIntegracionController(ServicioEventoIntegracion servicio)
    {
        _servicio = servicio;
    }

    /// <summary>
    /// Registra un evento externo. Estado inicial: Recibido.
    /// No conecta APIs reales todavia.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<EventoIntegracionResponse>> Crear(
        CrearEventoIntegracionRequest solicitud)
    {
        var respuesta = await _servicio.CrearAsync(solicitud);
        return CreatedAtAction(nameof(Crear), new { id = respuesta.Id }, respuesta);
    }
}
