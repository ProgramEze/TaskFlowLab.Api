# 10 - Riesgos

Riesgos tecnicos, de seguridad y de arquitectura identificados en el proyecto.

## Riesgos actuales

| Riesgo | Impacto | Mitigacion |
|--------|---------|------------|
| Conectar servicios externos antes de tener interfaces claras | Alto | Definir interfaz en Application primero, implementar Null Object en Infrastructure |
| Guardar credenciales en el repositorio | Critico | `.gitignore` bloquea `.env`, `credentials/`, `*.pem`, `client_secret*.json`, `token*.json` |
| Pedir scopes OAuth demasiado amplios | Alto | Pedir el menor permiso posible; documentar scopes usados |
| Permitir que un agente modifique codigo sin plan ni revision | Alto | Regla en CLAUDE.md: siempre proponer plan y esperar aprobacion |
| Agregar endpoints administrativos sin autorizacion | Alto | Todo endpoint sensible lleva `[Authorize]` |
| Repositorio Singleton con Dictionary no thread-safe | Medio | Usar siempre `ConcurrentDictionary` en repositorios Singleton |
| Features grandes sin brief previo | Medio | Invocar `/feature-brief` antes de implementar cualquier feature nueva |

## Riesgos resueltos

| Riesgo | Fecha | Como se resolvio |
|--------|-------|------------------|
| `settings.json` con comentarios JS invalidos | 2026-06-07 | Eliminados todos los comentarios |
| Flag `--wktree` incorrecto en worktree | 2026-06-07 | Corregido a `--worktree` |
| `Dictionary` no thread-safe en Singleton | 2026-06-07 | Reemplazado por `ConcurrentDictionary` |
