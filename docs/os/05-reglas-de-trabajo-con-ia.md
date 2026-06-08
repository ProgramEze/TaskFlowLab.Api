# 05 - Reglas de trabajo con IA

Como debe comportarse Claude Code en este proyecto.

## Reglas obligatorias

1. **Siempre proponer un plan antes de modificar archivos.** No implementar sin aprobacion explicita.
2. **No eliminar archivos** sin pedirlo con aprobacion explicita.
3. **No leer ni modificar** `.env`, `.env.local`, `secrets/` ni archivos `*.pem`.
4. **No instalar paquetes NuGet** sin justificar por que hacen falta.
5. **No cambiar el stack tecnologico** sin discusion previa.
6. **Responder siempre en español.**
7. **No usar bypass permissions** como costumbre.
8. **Implementar en cambios pequeños.** Una capa a la vez.

## Flujo seguro de trabajo

```
Entender → Planificar → Aislar (worktree si hace falta) → Implementar → Revisar con skill → Commitear
```

## Cuando usar cada herramienta

| Herramienta | Cuando usarla |
|-------------|---------------|
| Agente unico | Cambio puntual en una zona del codigo |
| Subagente (revisor-backend) | Revision de seguridad o analisis aislado |
| Skill revision-backend | Antes de cada commit |
| Skill feature-brief | Antes de implementar cualquier feature nueva |
| Worktree | Feature que toca varias capas en paralelo |
| Agent Team | Solo si hay trabajo genuinamente paralelo |
