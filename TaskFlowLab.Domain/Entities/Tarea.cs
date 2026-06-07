using TaskFlowLab.Domain.Enums;
using TaskFlowLab.Domain.Exceptions;

namespace TaskFlowLab.Domain.Entities;

public class Tarea
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public EstadoTarea Estado { get; private set; }
    public DateTime? FechaVencimiento { get; private set; }

    public Tarea(Guid id, string titulo, EstadoTarea estado, DateTime? fechaVencimiento)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("El Id de la tarea no puede ser un Guid vacío.", nameof(id));
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("El título de la tarea no puede ser nulo o vacío.", nameof(titulo));

        Id = id;
        Titulo = titulo;
        Estado = estado;
        FechaVencimiento = fechaVencimiento;
    }

    public void CambiarEstado(EstadoTarea nuevoEstado, DateTime fechaActual)
    {
        if (nuevoEstado == EstadoTarea.Completada
            && FechaVencimiento.HasValue
            && fechaActual > FechaVencimiento.Value)
        {
            throw new TareaVencidaException();
        }

        Estado = nuevoEstado;
    }
}
