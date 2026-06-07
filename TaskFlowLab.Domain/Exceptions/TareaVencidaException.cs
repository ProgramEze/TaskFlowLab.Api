namespace TaskFlowLab.Domain.Exceptions;

public class TareaVencidaException : Exception
{
    public TareaVencidaException()
        : base("Una tarea vencida no puede pasar al estado Completada.")
    {
    }
}
