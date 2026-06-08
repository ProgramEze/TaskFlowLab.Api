# Integracion futura: Google Antigravity

## Estado

No implementada. Documentacion de referencia pendiente.

## Que es

Antigravity es una plataforma de desarrollo centrada en agentes. Permite planificar, programar, navegar y validar tareas con menor intervencion humana desde un entorno IDE evolucionado.

## Criterio de uso

Usar agentes para acelerar tareas repetibles, no para reemplazar el criterio tecnico. En backend, cada cambio debe terminar en diff, build, tests y revision humana.

## Niveles de uso y riesgos

| Nivel | Uso | Riesgo |
|-------|-----|--------|
| Chat / panel | Pedir explicaciones, planes y cambios pequenos | Poca trazabilidad si no se copia el plan |
| Agent Manager | Ejecutar varias tareas en paralelo | Cambios simultaneos dificiles de revisar |
| Browser agent | Interactuar con navegador y consola | Exponer sesiones, formularios o datos privados |
| Agent Teams | Dividir features grandes | Conflictos de arquitectura si no hay lider claro |

## Prompt seguro de analisis

```
Revisa este proyecto como asistente de backend.

Reglas:
1. No ejecutes comandos destructivos.
2. No leas archivos .env, credentials, secrets ni tokens.
3. No modifiques codigo todavia.
4. Primero genera un plan con archivos a tocar.
5. Indica riesgos de seguridad.
6. Espera mi aprobacion antes de implementar.
```
