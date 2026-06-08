# 09 - Backlog de Skills

Skills futuras para automatizar tareas repetibles en el proyecto. No son compromisos, son candidatas a encapsular cuando el patron se repita 2 o 3 veces manualmente.

## Criterio para crear una skill

- Me descubro pegando siempre el mismo prompt.
- La tarea tiene pasos fijos y criterios de calidad repetibles.
- Quiero que el resultado quede en archivos del repo, no solo en el chat.

---

## Skills candidatas

| Skill | Disparador | Resultado esperado |
|-------|-----------|--------------------|
| `revisar-endpoint` | Al agregar un endpoint nuevo | Verifica DTOs, validacion, auth, tests y Swagger |
| `auditar-secreto` | Antes de cada commit | Busca `.env`, tokens, keys y archivos sensibles en el diff |
| `generar-doc-feature` | Al cerrar una feature | Actualiza docs con ruta, DTOs, reglas y pruebas |
| `revisar-integracion` | Antes de conectar un servicio externo | Chequea permisos, config, fallbacks y limites |
| `resumen-modulo` | Al cerrar un modulo del curso | Genera entrada en el log de aprendizaje |

---

## Skills ya creadas

| Skill | Ubicacion | Estado |
|-------|-----------|--------|
| `revision-backend` | `.claude/skills/revision-backend/` | Activa |
| `feature-brief` | `.claude/skills/feature-brief/` | Activa |
