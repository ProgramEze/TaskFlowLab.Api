using System.Collections.Concurrent;
using TaskFlowLab.Application.Interfaces;
using TaskFlowLab.Domain.Entities;

namespace TaskFlowLab.Infrastructure.Repositorios;

public class RepositorioEventoIntegracion : IRepositorioEventoIntegracion
{
    private readonly ConcurrentDictionary<Guid, EventoIntegracion> _almacen = new();

    public Task AgregarAsync(EventoIntegracion evento)
    {
        _almacen[evento.Id] = evento;
        return Task.CompletedTask;
    }

    public Task<EventoIntegracion?> ObtenerPorIdAsync(Guid id)
    {
        _almacen.TryGetValue(id, out var evento);
        return Task.FromResult(evento);
    }
}
