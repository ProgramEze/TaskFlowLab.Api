using TaskFlowLab.Domain.Enums;

namespace TaskFlowLab.Domain.Entities;

public class EventoIntegracion
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Proveedor { get; set; } = string.Empty;
    public string TipoEvento { get; set; } = string.Empty;
    public string ResumenPayload { get; set; } = string.Empty;
    public EstadoEventoIntegracion Estado { get; set; } = EstadoEventoIntegracion.Recibido;
    public DateTime FechaCreacionUtc { get; set; } = DateTime.UtcNow;
}
