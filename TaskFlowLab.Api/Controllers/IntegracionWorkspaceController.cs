using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlowLab.Application.Integrations;

namespace TaskFlowLab.Api.Controllers;

[ApiController]
[Route("api/integraciones/workspace")]
[Authorize]
public sealed class IntegracionWorkspaceController : ControllerBase
{
    private readonly IServicioAutomatizacionWorkspace _servicioWorkspace;

    public IntegracionWorkspaceController(IServicioAutomatizacionWorkspace servicioWorkspace)
    {
        _servicioWorkspace = servicioWorkspace;
    }

    /// <summary>
    /// Devuelve el estado actual de la integracion con Google Workspace.
    /// No expone credenciales ni tokens.
    /// </summary>
    [HttpGet("estado")]
    public async Task<ActionResult<EstadoIntegracionWorkspace>> ObtenerEstado(
        CancellationToken cancellationToken)
    {
        var estado = await _servicioWorkspace.ObtenerEstadoAsync(cancellationToken);
        return Ok(estado);
    }
}
