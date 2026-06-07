using TaskFlowLab.Application.DTOs;

namespace TaskFlowLab.Application.Interfaces;

public interface ITareaServicio
{
    Task CambiarEstadoAsync(Guid tareaId, ActualizarEstadoTareaDto dto);
}
