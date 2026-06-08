# 08 - Decisions Lock

Decisiones tecnicas que no deben cambiarse sin motivo justificado. Si una decision cambia, se registra la fecha y el motivo aqui mismo.

---

## DL-001 - Domain no depende de Infrastructure

Fecha: 2026-06-07
Estado: Activa

Las entidades y reglas de negocio viven en Domain sin referencias a EF Core, PostgreSQL, Google APIs ni frameworks de infraestructura.

**Motivo:** proteger el nucleo del sistema y facilitar tests unitarios puros.

---

## DL-002 - Integraciones externas detras de interfaces

Fecha: 2026-06-07
Estado: Activa

Cualquier integracion con Google Workspace, CLI, MCP o servicios externos se accede desde Application mediante interfaces. Infrastructure provee las implementaciones concretas.

**Motivo:** evitar que controladores o casos de uso dependan directamente de herramientas externas.

---

## DL-003 - Secretos fuera del repositorio

Fecha: 2026-06-07
Estado: Activa

`.env`, `appsettings.Development.json` con secretos, `credentials.json`, `client_secret.json` y tokens OAuth no se versionan nunca.

**Motivo:** seguridad y responsabilidad profesional.

---

## DL-004 - Null Object antes que integracion real

Fecha: 2026-06-08
Estado: Activa

Antes de conectar cualquier servicio externo real, se crea una implementacion nula que permite compilar, inyectar y testear sin credenciales.

**Motivo:** la arquitectura queda definida sin depender de cuentas, tokens ni servicios de terceros.

---

## DL-005 - Todo el codigo en espanol

Fecha: 2026-06-07
Estado: Activa

Clases, metodos, propiedades, variables, interfaces, enums, commits y comentarios siempre en espanol.

**Motivo:** coherencia didactica y legibilidad para el autor.
