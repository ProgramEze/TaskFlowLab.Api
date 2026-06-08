namespace TaskFlowLab.Application.DTOs.EventosIntegracion;

public class EventoIntegracionResponse
{
    public Guid Id { get; set; }
    public string Proveedor { get; set; } = string.Empty;
    public string TipoEvento { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public DateTime FechaCreacionUtc { get; set; }
}
