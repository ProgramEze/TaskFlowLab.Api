using Moq;
using FluentAssertions;
using TaskFlowLab.Application.DTOs.EventosIntegracion;
using TaskFlowLab.Application.Interfaces;
using TaskFlowLab.Application.Servicios;

namespace TaskFlowLab.Tests;

public class ServicioEventoIntegracionTests
{
    [Fact]
    public async Task CrearAsync_CuandoProveedorEsVacio_DebeLanzarArgumentException()
    {
        var repositorio = new Mock<IRepositorioEventoIntegracion>();
        var servicio = new ServicioEventoIntegracion(repositorio.Object);

        var solicitud = new CrearEventoIntegracionRequest
        {
            Proveedor = "",
            TipoEvento = "lead.creado",
            ResumenPayload = "Payload de prueba"
        };

        Func<Task> accion = async () => await servicio.CrearAsync(solicitud);

        await accion.Should().ThrowAsync<ArgumentException>()
            .WithMessage("El proveedor es obligatorio.");
    }

    [Fact]
    public async Task CrearAsync_CuandoTipoEventoEsVacio_DebeLanzarArgumentException()
    {
        var repositorio = new Mock<IRepositorioEventoIntegracion>();
        var servicio = new ServicioEventoIntegracion(repositorio.Object);

        var solicitud = new CrearEventoIntegracionRequest
        {
            Proveedor = "n8n",
            TipoEvento = "",
            ResumenPayload = "Payload de prueba"
        };

        Func<Task> accion = async () => await servicio.CrearAsync(solicitud);

        await accion.Should().ThrowAsync<ArgumentException>()
            .WithMessage("El tipo de evento es obligatorio.");
    }

    [Fact]
    public async Task CrearAsync_CuandoDatosValidos_DebeGuardarYDevolverRespuesta()
    {
        var repositorio = new Mock<IRepositorioEventoIntegracion>();
        var servicio = new ServicioEventoIntegracion(repositorio.Object);

        var solicitud = new CrearEventoIntegracionRequest
        {
            Proveedor = "n8n",
            TipoEvento = "lead.creado",
            ResumenPayload = "Nombre: Juan, Email: juan@ejemplo.com"
        };

        var respuesta = await servicio.CrearAsync(solicitud);

        respuesta.Id.Should().NotBeEmpty();
        respuesta.Proveedor.Should().Be("n8n");
        respuesta.TipoEvento.Should().Be("lead.creado");
        respuesta.Estado.Should().Be("Recibido");
        respuesta.FechaCreacionUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));

        repositorio.Verify(r => r.AgregarAsync(It.IsAny<TaskFlowLab.Domain.Entities.EventoIntegracion>()), Times.Once);
    }
}
