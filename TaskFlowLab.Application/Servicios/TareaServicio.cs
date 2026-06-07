using TaskFlowLab.Application.DTOs;
using TaskFlowLab.Application.Exceptions;
using TaskFlowLab.Application.Interfaces;

namespace TaskFlowLab.Application.Servicios;

public class TareaServicio : ITareaServicio
{
    private readonly ITareaRepositorio _repositorio;

    public TareaServicio(ITareaRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task CambiarEstadoAsync(Guid tareaId, ActualizarEstadoTareaDto dto)
    {
        var tarea = await _repositorio.ObtenerPorIdAsync(tareaId)
            ?? throw new TareaNoEncontradaException(tareaId);

        tarea.CambiarEstado(dto.NuevoEstado!.Value, DateTime.UtcNow);

        await _repositorio.ActualizarAsync(tarea);
    }
}
