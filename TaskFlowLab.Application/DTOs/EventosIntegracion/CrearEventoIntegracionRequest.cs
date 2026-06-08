namespace TaskFlowLab.Application.DTOs.EventosIntegracion;

public class CrearEventoIntegracionRequest
{
    public string Proveedor { get; set; } = string.Empty;
    public string TipoEvento { get; set; } = string.Empty;
    public string ResumenPayload { get; set; } = string.Empty;
}
