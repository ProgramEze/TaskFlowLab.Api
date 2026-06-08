using TaskFlowLab.Application.Integrations;

namespace TaskFlowLab.Infrastructure.Integrations;

public sealed class NullServicioAutomatizacionWorkspace : IServicioAutomatizacionWorkspace
{
    public Task<EstadoIntegracionWorkspace> ObtenerEstadoAsync(
        CancellationToken cancellationToken = default)
    {
        var estado = new EstadoIntegracionWorkspace(
            Habilitado: false,
            Proveedor: "ninguno",
            Mensaje: "La integracion con Google Workspace no esta configurada.");

        return Task.FromResult(estado);
    }

    public Task<ResultadoExportacionWorkspace> ExportarResumenProyectoAsync(
        ResumenProyectoWorkspace resumen,
        CancellationToken cancellationToken = default)
    {
        var resultado = new ResultadoExportacionWorkspace(
            Exitoso: false,
            IdExterno: null,
            Mensaje: "Exportacion deshabilitada hasta que se configuren credenciales y scopes.");

        return Task.FromResult(resultado);
    }
}
