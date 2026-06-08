namespace TaskFlowLab.Application.Integrations;

public interface IServicioAutomatizacionWorkspace
{
    Task<EstadoIntegracionWorkspace> ObtenerEstadoAsync(
        CancellationToken cancellationToken = default);

    Task<ResultadoExportacionWorkspace> ExportarResumenProyectoAsync(
        ResumenProyectoWorkspace resumen,
        CancellationToken cancellationToken = default);
}

public sealed record EstadoIntegracionWorkspace(
    bool Habilitado,
    string Proveedor,
    string Mensaje);

public sealed record ResumenProyectoWorkspace(
    string NombreProyecto,
    string ObjetivoActual,
    IReadOnlyList<string> Decisiones);

public sealed record ResultadoExportacionWorkspace(
    bool Exitoso,
    string? IdExterno,
    string Mensaje);
