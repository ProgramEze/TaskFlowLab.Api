using Microsoft.AspNetCore.Mvc;
using TaskFlowLab.Application.DTOs;
using TaskFlowLab.Application.Exceptions;
using TaskFlowLab.Application.Interfaces;
using TaskFlowLab.Domain.Exceptions;

namespace TaskFlowLab.Api.Controllers;

[ApiController]
[Route("api/tareas")]
public class TareasController : ControllerBase
{
    private readonly ITareaServicio _servicio;

    public TareasController(ITareaServicio servicio)
    {
        _servicio = servicio;
    }

    [HttpPatch("{id}/estado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CambiarEstado(Guid id, [FromBody] ActualizarEstadoTareaDto dto)
    {
        try
        {
            await _servicio.CambiarEstadoAsync(id, dto);
            return NoContent();
        }
        catch (TareaNoEncontradaException)
        {
            return NotFound();
        }
        catch (TareaVencidaException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
