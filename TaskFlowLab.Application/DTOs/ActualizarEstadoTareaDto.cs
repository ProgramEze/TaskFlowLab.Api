using System.ComponentModel.DataAnnotations;
using TaskFlowLab.Domain.Enums;

namespace TaskFlowLab.Application.DTOs;

public class ActualizarEstadoTareaDto
{
    [Required]
    [EnumDataType(typeof(EstadoTarea))]
    public EstadoTarea? NuevoEstado { get; set; }
}
