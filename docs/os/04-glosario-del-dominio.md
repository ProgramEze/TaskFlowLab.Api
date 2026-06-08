# 04 - Glosario del dominio

Terminos del negocio usados en el proyecto. Sirve para que el agente y el desarrollador hablen el mismo idioma.

## Terminos principales

| Termino | Definicion |
|---------|------------|
| **Tarea** | Unidad de trabajo con titulo, descripcion, estado, prioridad y fecha de vencimiento opcional. |
| **Estado de tarea** | Enum con valores: Pendiente, EnProgreso, Completada, Cancelada. |
| **Prioridad** | Enum con valores: Baja, Media, Alta, Critica. |
| **FechaVencimiento** | DateTime opcional. Si existe y es anterior a DateTime.UtcNow, la tarea esta vencida. |
| **Tarea vencida** | Tarea cuya FechaVencimiento es anterior al momento actual. No puede pasar al estado Completada. |
| **Workspace** | Espacio de trabajo compartido que agrupa proyectos y miembros. |
| **Proyecto** | Agrupacion de tareas dentro de un workspace. |
| **Miembro** | Usuario con acceso a un workspace. Puede tener rol Owner o Member. |
| **Brief tecnico** | Documento Markdown generado antes de implementar una feature. Especifica alcance, reglas, endpoints y tests. |
