namespace TaskFlowLab.Application.Exceptions;

public class TareaNoEncontradaException : Exception
{
    public TareaNoEncontradaException(Guid tareaId)
        : base($"No se encontró la tarea con Id {tareaId}.")
    {
    }
}
