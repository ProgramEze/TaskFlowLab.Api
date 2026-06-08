# 02 - Decisiones tecnicas

## ADR-001 - Usar Clean Architecture moderada

Fecha: 2026-06-07
Estado: Aceptada

### Contexto

El proyecto busca practicar backend profesional sin caer en sobreingenieria.

### Decision

Separar el codigo en cuatro capas principales: Domain, Application, Infrastructure y Api.

### Consecuencia positiva

La logica de negocio queda separada de controllers, EF Core y detalles de infraestructura.

### Costo aceptado

Hay mas carpetas y proyectos que en una API minima, pero el aprendizaje es mas transferible a proyectos reales.

---

## ADR-002 - Todo el codigo en español

Fecha: 2026-06-07
Estado: Aceptada

### Contexto

El proyecto es un laboratorio de aprendizaje personal.

### Decision

Clases, metodos, propiedades, variables, interfaces, enums, commits y comentarios siempre en español. Solo los nombres de frameworks y paquetes externos quedan en ingles.

### Consecuencia positiva

Mayor legibilidad para el autor y coherencia con el objetivo didactico.

---

## ADR-003 - FechaVencimiento guarda fecha y hora

Fecha: 2026-06-07
Estado: Aceptada

### Contexto

Al implementar la regla de tarea vencida, se debatio si guardar solo la fecha o fecha + hora.

### Decision

Guardar DateTime completo para que las tareas venzan en un momento exacto, no al inicio del dia.

### Consecuencia positiva

Mayor precision para reglas de negocio temporales.

---

## ADR-004 - TareaNoEncontradaException vive en Application

Fecha: 2026-06-07
Estado: Aceptada

### Contexto

Se debatio si la excepcion de tarea no encontrada pertenece a Domain o Application.

### Decision

Vive en Application porque Domain no conoce repositorios ni operaciones de busqueda.

### Consecuencia positiva

Domain permanece puro: solo entidades, enums y reglas de negocio sin dependencias externas.
