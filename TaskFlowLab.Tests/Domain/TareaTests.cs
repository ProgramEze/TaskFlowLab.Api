using TaskFlowLab.Domain.Entities;
using TaskFlowLab.Domain.Enums;
using TaskFlowLab.Domain.Exceptions;

namespace TaskFlowLab.Tests.Domain;

public class TareaTests
{
    // Fecha fija para que los tests no dependan del reloj del sistema
    private static readonly DateTime FechaActual = new DateTime(2026, 6, 7, 15, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void CambiarEstado_TareaVencida_IntentarCompletar_LanzaTareaVencidaException()
    {
        // Arrange
        var tarea = new Tarea(Guid.NewGuid(), "Tarea de prueba", EstadoTarea.Pendiente,
            FechaActual.AddDays(-1)); // vencida ayer

        // Act & Assert
        Assert.Throws<TareaVencidaException>(() =>
            tarea.CambiarEstado(EstadoTarea.Completada, FechaActual));
    }

    [Fact]
    public void CambiarEstado_TareaNoVencida_IntentarCompletar_CambiaEstadoExitosamente()
    {
        // Arrange
        var tarea = new Tarea(Guid.NewGuid(), "Tarea de prueba", EstadoTarea.Pendiente,
            FechaActual.AddDays(1)); // vence mañana

        // Act
        tarea.CambiarEstado(EstadoTarea.Completada, FechaActual);

        // Assert
        Assert.Equal(EstadoTarea.Completada, tarea.Estado);
    }

    [Fact]
    public void CambiarEstado_TareaVencida_IntentarCancelar_CambiaEstadoExitosamente()
    {
        // Arrange
        var tarea = new Tarea(Guid.NewGuid(), "Tarea de prueba", EstadoTarea.Pendiente,
            FechaActual.AddDays(-1)); // vencida ayer

        // Act
        tarea.CambiarEstado(EstadoTarea.Cancelada, FechaActual);

        // Assert
        Assert.Equal(EstadoTarea.Cancelada, tarea.Estado);
    }

    [Fact]
    public void CambiarEstado_FechaActualMayorAFechaVencimientoMismoDia_LanzaTareaVencidaException()
    {
        // Arrange: vencimiento hoy a las 9:00, intento a las 15:00
        var tarea = new Tarea(Guid.NewGuid(), "Tarea de prueba", EstadoTarea.Pendiente,
            new DateTime(2026, 6, 7, 9, 0, 0, DateTimeKind.Utc));

        // Act & Assert
        Assert.Throws<TareaVencidaException>(() =>
            tarea.CambiarEstado(EstadoTarea.Completada,
                new DateTime(2026, 6, 7, 15, 0, 0, DateTimeKind.Utc)));
    }

    [Fact]
    public void CambiarEstado_SinFechaVencimiento_IntentarCompletar_CambiaEstadoExitosamente()
    {
        // Arrange
        var tarea = new Tarea(Guid.NewGuid(), "Tarea de prueba", EstadoTarea.Pendiente,
            fechaVencimiento: null);

        // Act
        tarea.CambiarEstado(EstadoTarea.Completada, FechaActual);

        // Assert
        Assert.Equal(EstadoTarea.Completada, tarea.Estado);
    }
}
