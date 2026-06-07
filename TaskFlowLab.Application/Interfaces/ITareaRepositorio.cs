using TaskFlowLab.Domain.Entities;

namespace TaskFlowLab.Application.Interfaces;

public interface ITareaRepositorio
{
    Task AgregarAsync(Tarea tarea);
    Task<Tarea?> ObtenerPorIdAsync(Guid id);
    Task ActualizarAsync(Tarea tarea);
}
