using System.Collections.Concurrent;
using TaskFlowLab.Application.Interfaces;
using TaskFlowLab.Domain.Entities;

namespace TaskFlowLab.Infrastructure.Repositorios;

public class TareaRepositorio : ITareaRepositorio
{
    private readonly ConcurrentDictionary<Guid, Tarea> _tareas = new();

    public Task AgregarAsync(Tarea tarea)
    {
        _tareas.TryAdd(tarea.Id, tarea);
        return Task.CompletedTask;
    }

    public Task<Tarea?> ObtenerPorIdAsync(Guid id)
    {
        _tareas.TryGetValue(id, out var tarea);
        return Task.FromResult(tarea);
    }

    public Task ActualizarAsync(Tarea tarea)
    {
        _tareas[tarea.Id] = tarea;
        return Task.CompletedTask;
    }
}
