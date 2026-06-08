---
description: Genera un brief tecnico de feature para TaskFlowLab.Api. Usar cuando se proponga una feature nueva, un endpoint, una regla de negocio o una mejora que todavia no esta suficientemente especificada.
---

# Skill: feature-brief

Converti la solicitud en un brief tecnico breve, claro y accionable.

## Entrada

Solicitud original:

$ARGUMENTS

## Reglas

- Responder siempre en español.
- No escribir codigo de implementacion todavia.
- No modificar archivos de produccion.
- Si falta informacion critica, listar preguntas al final.
- Mantener el enfoque en ASP.NET Core, Clean Architecture moderada, EF Core y tests.
- Respetar el orden de capas:
  1. Domain
  2. Application
  3. Infrastructure
  4. Api
  5. Tests

## Salida obligatoria

Crear o proponer un archivo en:

```
docs/features/YYYY-MM-DD-nombre-feature.md
```

El documento debe incluir:

1. Resumen de la feature.
2. Problema que resuelve.
3. Alcance incluido.
4. Alcance excluido.
5. Reglas de negocio.
6. Impacto por capa.
7. Endpoints propuestos.
8. DTOs necesarios.
9. Tests recomendados.
10. Riesgos tecnicos.
11. Preguntas abiertas.
12. Checklist antes de implementar.
