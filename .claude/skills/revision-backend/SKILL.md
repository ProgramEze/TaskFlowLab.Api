---
name: revision-backend
description: Revisa cambios de backend en TaskFlowLab.Api antes de un commit.
    Usar cuando se pida revisar un cambio, preparar un commit, detectar riesgos
    en una feature o verificar que la arquitectura no fue rota.
allowed-tools: Read Grep Glob Bash
---

# Skill: revision-backend

## Objetivo

Revisar los cambios actuales de backend en TaskFlowLab.Api antes de confirmar
el trabajo. No modificar archivos. Solo analizar e informar.

## Contexto del proyecto

- Solución: Clean Architecture moderada con 5 proyectos.
- Capas: Dominio, Aplicacion, Infraestructura, Api, Pruebas.
- Stack: C# / ASP.NET Core 8 / EF Core / PostgreSQL / xUnit.
- Convención: todo el código en español (clases, métodos, variables, comentarios).
- Regla de oro: Dominio no depende de Infraestructura ni de Api.

## Pasos de revisión

1. Ejecutar `git status` para ver qué archivos cambiaron.
2. Ejecutar `git diff` para leer los cambios en detalle.
3. Clasificar los archivos modificados por capa:
    - TaskFlowLab.Dominio
    - TaskFlowLab.Aplicacion
    - TaskFlowLab.Infraestructura
    - TaskFlowLab.Api
    - TaskFlowLab.Pruebas
4. Detectar riesgos en cada capa:
    - Lógica de negocio fuera de Dominio o Aplicacion.
    - Dependencias incorrectas entre capas.
    - Secretos o valores hardcodeados (JWT keys, connection strings).
    - Falta de validaciones en endpoints.
    - Cambios sin tests asociados.
    - Nombres en inglés donde deberían estar en español.
5. Proponer lista corta de correcciones priorizadas.
6. Sugerir comandos de validación:
   `dotnet build` → `dotnet test`
7. Emitir veredicto final.

## Formato de respuesta

- **Resumen del cambio**: qué se modificó y en qué capas.
- **Riesgos encontrados**: listados por severidad (alto / medio / bajo).
- **Correcciones recomendadas**: concretas y ordenadas.
- **Tests sugeridos**: qué habría que probar.
- **Veredicto**: listo para commit / revisar antes de commit.

## Restricciones

- No modificar archivos bajo ninguna circunstancia.
- No instalar paquetes NuGet.
- No ejecutar comandos destructivos.
- Solo leer, analizar e informar.
