using TaskFlowLab.Application.DTOs.EventosIntegracion;
using TaskFlowLab.Application.Interfaces;
using TaskFlowLab.Domain.Entities;

namespace TaskFlowLab.Application.Servicios;

public class ServicioEventoIntegracion
{
    private readonly IRepositorioEventoIntegracion _repositorio;

    public ServicioEventoIntegracion(IRepositorioEventoIntegracion repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<EventoIntegracionResponse> CrearAsync(CrearEventoIntegracionRequest solicitud)
    {
        if (string.IsNullOrWhiteSpace(solicitud.Proveedor))
            throw new ArgumentException("El proveedor es obligatorio.");

        if (string.IsNullOrWhiteSpace(solicitud.TipoEvento))
            throw new ArgumentException("El tipo de evento es obligatorio.");

        var evento = new EventoIntegracion
        {
            Proveedor = solicitud.Proveedor.Trim(),
            TipoEvento = solicitud.TipoEvento.Trim(),
            ResumenPayload = solicitud.ResumenPayload.Trim()
        };

        await _repositorio.AgregarAsync(evento);

        return new EventoIntegracionResponse
        {
            Id = evento.Id,
            Proveedor = evento.Proveedor,
            TipoEvento = evento.TipoEvento,
            Estado = evento.Estado.ToString(),
            FechaCreacionUtc = evento.FechaCreacionUtc
        };
    }
}
