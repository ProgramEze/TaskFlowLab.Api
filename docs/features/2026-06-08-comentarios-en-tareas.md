# Feature Brief: Comentarios en tareas

**Fecha:** 2026-06-08
**Estado:** Aprobada — lista para implementar

**Decisiones cerradas (2026-06-08):**
- `UsuarioId`: string libre en el body (email o nombre de usuario).
- Autorización provisional: header `X-Usuario-Id` en PATCH y DELETE.
- Orden de listado: ASC (más antiguo primero).

---

## 1. Resumen

Permitir que los usuarios del workspace agreguen comentarios a tareas existentes. Cada comentario registra autor, texto, fecha de creación y la referencia a la tarea. Los comentarios son mutables (edición y eliminación lógica) por su propio autor.

---

## 2. Problema que resuelve

Las tareas actuales no tienen un canal de comunicación interno. Cualquier discusión, aclaración o nota colaborativa ocurre fuera del sistema. Esta feature introduce un historial de comentarios que:

- Centraliza la comunicación alrededor de cada tarea.
- Deja trazabilidad de decisiones tomadas.
- Evita perder contexto entre miembros del workspace.

---

## 3. Alcance incluido

- Crear un comentario en una tarea existente.
- Listar todos los comentarios activos de una tarea (ordenados por fecha ASC).
- Editar el contenido de un comentario propio.
- Eliminar un comentario propio (eliminación lógica, no física).
- Validaciones básicas: contenido no vacío, longitud máxima.
- Auditoría mínima: autor, fecha de creación, fecha de modificación.

---

## 4. Alcance excluido

- Menciones (`@usuario`).
- Reacciones o emojis.
- Archivos adjuntos.
- Notificaciones en tiempo real (WebSockets / SignalR).
- Comentarios anidados (threads / respuestas).
- Historial de ediciones anteriores.
- Permisos de administrador sobre comentarios ajenos.
- Paginación (puede agregarse en iteración posterior).

---

## 5. Reglas de negocio

| # | Regla |
|---|-------|
| RN-01 | Un comentario requiere `UsuarioId`, `Contenido` y referencia a una `Tarea` existente. |
| RN-02 | El `Contenido` debe tener entre 1 y 5000 caracteres. |
| RN-03 | Solo el autor (`UsuarioId`) puede editar o eliminar su comentario. |
| RN-04 | La edición actualiza `FechaModificacion`; el contenido original no se conserva. |
| RN-05 | La eliminación es lógica: se registra `FechaEliminacion` y el comentario deja de aparecer en listados. |
| RN-06 | Los listados devuelven únicamente comentarios activos, ordenados por `FechaCreacion` ASC. |
| RN-07 | No se puede comentar sobre una tarea que no existe. |

---

## 6. Impacto por capa

### Domain — `TaskFlowLab.Domain`

**Nueva entidad:** `Comentario`

```
Comentario.cs
  - Id (Guid)
  - TareaId (Guid)
  - UsuarioId (string)
  - Contenido (string)
  - FechaCreacion (DateTime)
  - FechaModificacion (DateTime?)
  - FechaEliminacion (DateTime?)

Métodos:
  - Comentario(Guid id, Guid tareaId, string usuarioId, string contenido, DateTime fechaCreacion)
  - Editar(string nuevoContenido, DateTime ahora)
  - Eliminar(DateTime ahora)
```

**Nuevas excepciones de dominio:**

- `ComentarioContenidoInvalidoException` — contenido vacío, nulo o que excede el límite.
- `ComentarioNoEncontradoException` — comentario no existe o fue eliminado.
- `OperacionNoAutorizadaException` — usuario intenta editar/eliminar comentario ajeno.

---

### Application — `TaskFlowLab.Application`

**Nuevas interfaces:**

```csharp
// Interfaces/IComentarioRepositorio.cs
Task AgregarAsync(Comentario comentario);
Task<Comentario?> ObtenerPorIdAsync(Guid id);
Task<List<Comentario>> ObtenerPorTareaAsync(Guid tareaId);
Task ActualizarAsync(Comentario comentario);

// Interfaces/IComentarioServicio.cs
Task<Guid> CrearComentarioAsync(Guid tareaId, CrearComentarioDto dto);
Task<List<ComentarioDto>> ObtenerComentariosDeTareaAsync(Guid tareaId);
Task EditarComentarioAsync(Guid comentarioId, EditarComentarioDto dto, string usuarioActual);
Task EliminarComentarioAsync(Guid comentarioId, string usuarioActual);
```

**Nuevos DTOs:**

```
CrearComentarioDto  → UsuarioId (string), Contenido (string)
EditarComentarioDto → Contenido (string)
ComentarioDto       → Id, TareaId, UsuarioId, Contenido,
                      FechaCreacion, FechaModificacion (nullable)
```

**Nuevo servicio:** `ComentarioServicio`

Orquesta: verificación de tarea existente, delegación a la entidad de dominio, mapeo a DTO, manejo de excepciones.

---

### Infrastructure — `TaskFlowLab.Infrastructure`

**Nueva implementación:** `ComentarioRepositorio`

- Storage: `ConcurrentDictionary<Guid, Comentario>` (consistente con `TareaRepositorio`).
- `ObtenerPorTareaAsync` filtra por `TareaId` y excluye registros con `FechaEliminacion != null`.

---

### Api — `TaskFlowLab.Api`

**Nuevo controlador:** `ComentariosController`

Ruta base: `api/tareas/{tareaId}/comentarios`

Registro en `Program.cs`:

```csharp
builder.Services.AddSingleton<IComentarioRepositorio, ComentarioRepositorio>();
builder.Services.AddScoped<IComentarioServicio, ComentarioServicio>();
```

---

### Tests — `TaskFlowLab.Tests`

Ver sección 9.

---

## 7. Endpoints propuestos

### `POST /api/tareas/{tareaId}/comentarios`

Crea un nuevo comentario en la tarea indicada.

**Body:**
```json
{
  "usuarioId": "ezequiel",
  "contenido": "Este bloqueo depende del ticket #45."
}
```

**Respuestas:**
| Código | Motivo |
|--------|--------|
| 201 Created | Comentario creado. Body: `ComentarioDto`. |
| 400 Bad Request | Contenido inválido (vacío o demasiado largo). |
| 404 Not Found | La tarea no existe. |

---

### `GET /api/tareas/{tareaId}/comentarios`

Devuelve los comentarios activos de la tarea, ordenados por fecha ASC.

**Respuestas:**
| Código | Motivo |
|--------|--------|
| 200 OK | Lista de `ComentarioDto` (puede ser vacía). |
| 404 Not Found | La tarea no existe. |

---

### `PATCH /api/tareas/{tareaId}/comentarios/{comentarioId}`

Edita el contenido de un comentario existente. El autor se identifica mediante el header `X-Usuario-Id`.

**Headers requeridos:**
```
X-Usuario-Id: ezequiel
```

**Body:**
```json
{
  "contenido": "Corrección: el bloqueo es del ticket #47."
}
```

**Respuestas:**
| Código | Motivo |
|--------|--------|
| 204 No Content | Comentario editado. |
| 400 Bad Request | Contenido inválido. |
| 403 Forbidden | El usuario no es el autor. |
| 404 Not Found | Tarea o comentario no encontrado. |

---

### `DELETE /api/tareas/{tareaId}/comentarios/{comentarioId}`

Elimina lógicamente un comentario (solo el autor puede hacerlo).

El `usuarioId` del solicitante se envía en el header `X-Usuario-Id`.

**Headers requeridos:**
```
X-Usuario-Id: ezequiel
```

**Respuestas:**
| Código | Motivo |
|--------|--------|
| 204 No Content | Comentario eliminado. |
| 403 Forbidden | El usuario no es el autor. |
| 404 Not Found | Tarea o comentario no encontrado. |

---

## 8. DTOs necesarios

### `CrearComentarioDto`
```csharp
public class CrearComentarioDto
{
    [Required]
    public string UsuarioId { get; set; } = string.Empty;

    [Required]
    [StringLength(5000, MinimumLength = 1)]
    public string Contenido { get; set; } = string.Empty;
}
```

### `EditarComentarioDto`
```csharp
public class EditarComentarioDto
{
    [Required]
    [StringLength(5000, MinimumLength = 1)]
    public string Contenido { get; set; } = string.Empty;
}
```

### `ComentarioDto`
```csharp
public class ComentarioDto
{
    public Guid Id { get; set; }
    public Guid TareaId { get; set; }
    public string UsuarioId { get; set; } = string.Empty;
    public string Contenido { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
```

---

## 9. Tests recomendados

### Unitarios — dominio (`ComentarioTests.cs`)

- Crear comentario con datos válidos → propiedades asignadas correctamente.
- Crear comentario con contenido vacío → `ComentarioContenidoInvalidoException`.
- Crear comentario con contenido de 5001 caracteres → `ComentarioContenidoInvalidoException`.
- `Editar` actualiza `Contenido` y asigna `FechaModificacion`.
- `Eliminar` asigna `FechaEliminacion`.

### Unitarios — servicio (`ComentarioServicioTests.cs`)

- Crear comentario en tarea inexistente → `TareaNoEncontradaException`.
- Listar comentarios excluye los eliminados.
- Editar como no-autor → `OperacionNoAutorizadaException`.
- Eliminar como no-autor → `OperacionNoAutorizadaException`.
- Editar comentario inexistente → `ComentarioNoEncontradoException`.

### Integración — controller (`ComentariosControllerTests.cs`)

- `POST` con datos válidos → 201 + `ComentarioDto` en body.
- `GET` sobre tarea con comentarios → 200 + lista ordenada.
- `GET` sobre tarea sin comentarios → 200 + lista vacía.
- `GET` sobre tarea inexistente → 404.
- `PATCH` sin ser autor → 403.
- `DELETE` como autor → 204.

---

## 10. Riesgos técnicos

| Riesgo | Impacto | Mitigación |
|--------|---------|-----------|
| `UsuarioId` viene del cliente (sin JWT) | Alto en producción; aceptable en laboratorio | Documentar que debe venir de claims cuando haya autenticación |
| Pérdida de datos al reiniciar (storage en memoria) | Medio | Fuera de alcance del laboratorio; EF Core + PostgreSQL en iteración futura |
| Sin paginación en listado | Bajo ahora | Agregar paginación si se supera un umbral razonable |
| Concurrencia en `ConcurrentDictionary` al editar | Bajo | Patrón ya establecido en `TareaRepositorio`; aceptar misma solución |

---

## 11. Preguntas abiertas

~~1. **Identificador de usuario:** string libre en el body.~~ ✓ Resuelto
~~2. **Longitud máxima:** 5000 caracteres.~~ ✓ Aceptado
~~4. **Autoría en PATCH/DELETE:** header `X-Usuario-Id`.~~ ✓ Resuelto
~~5. **Orden de listado:** ASC.~~ ✓ Resuelto

3. **Ventana de edición:** ¿El autor puede editar indefinidamente, o solo dentro de N minutos de la creación? (No bloqueante — se asume edición indefinida para el lab.)

---

## 12. Checklist antes de implementar

- [x] Identificador de usuario: string en body.
- [x] Autorización provisional: header `X-Usuario-Id`.
- [x] Orden de listado: ASC.
- [ ] Crear rama `feature/comentarios-en-tareas`.
- [ ] Aprobar este brief explícitamente antes de escribir código.
- [ ] Implementar en orden: Domain → Application → Infrastructure → Api → Tests.
- [ ] Ejecutar `dotnet build` sin errores.
- [ ] Ejecutar `dotnet test` sin fallos.
- [ ] Revisar Swagger para validar contratos de endpoints.
