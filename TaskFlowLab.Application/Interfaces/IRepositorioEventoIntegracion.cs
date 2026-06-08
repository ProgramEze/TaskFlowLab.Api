using TaskFlowLab.Domain.Entities;

namespace TaskFlowLab.Application.Interfaces;

public interface IRepositorioEventoIntegracion
{
    Task AgregarAsync(EventoIntegracion evento);
    Task<EventoIntegracion?> ObtenerPorIdAsync(Guid id);
}
