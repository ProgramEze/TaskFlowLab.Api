# TaskFlowLab.Api — Contexto del proyecto

## Sobre el autor

Soy Ezequiel, desarrollador backend junior trabajando con C#, ASP.NET Core,
PostgreSQL y Docker. Este es un laboratorio de aprendizaje paralelo a
TaskFlow Pro API, mi proyecto principal de portfolio.

## Objetivo del laboratorio

Practicar el uso de Claude Code como copiloto de backend sobre un proyecto
real construido desde cero. Cada módulo del curso agrega una capa nueva.
No es un proyecto de producción: es un entorno controlado de aprendizaje.

## Stack

- Lenguaje: C# (.NET 8)
- Framework: ASP.NET Core 8
- ORM: Entity Framework Core
- Base de datos: PostgreSQL
- Testing: xUnit
- Arquitectura: Clean Architecture moderada
- Control de versiones: Git / GitHub (github.com/ProgramEze)

## Arquitectura y capas

TaskFlowLab.Domain → entidades, enums, reglas puras del dominio.
Sin dependencias de infraestructura.

TaskFlowLab.Application → DTOs, interfaces, servicios y casos de uso.
Solo depende de Domain.

TaskFlowLab.Infrastructure → persistencia, repositorios, EF Core, migraciones.
Depende de Application y Domain.

TaskFlowLab.Api → controllers, middleware, Swagger, configuración.
Depende de Application e Infrastructure.

TaskFlowLab.Tests → pruebas unitarias e integración.
Depende de Application y Domain.

## Regla de oro de arquitectura

Domain no debe conocer ni depender de Infrastructure ni de Api.
El núcleo del negocio no debe saber cómo se persiste ni cómo se expone.

## Convenciones de código

- Todo en español: clases, métodos, propiedades, variables, interfaces, enums.
- Comentarios en español.
- Commits en español.
- Sin excepciones: ni siquiera nombres de DTOs, controllers o repositorios van en inglés.
- Async/await en todos los métodos de acceso a datos.
- Repositorios con interfaz en Application e implementación en Infrastructure.
- Validaciones de dominio en Domain, no en los controllers.
- DTOs separados de las entidades del dominio.

## Orden para implementar cualquier feature

1. Analizar el código existente sin modificar nada.
2. Proponer un plan y esperar aprobación explícita.
3. Domain (entidad, enum, regla de negocio si corresponde).
4. Application (interfaces, DTOs, servicio o caso de uso).
5. Infrastructure (repositorio, migración si corresponde).
6. Api (controller, endpoint, Swagger).
7. Tests (unitarios y/o integración).
8. Validar con dotnet build y dotnet test.

## Archivos y carpetas protegidas

- .env y .env.local: nunca leer ni modificar.
- secrets/: acceso completamente bloqueado.
- appsettings.json: solo lectura, no modificar sin aprobación.
- \*.csproj: no agregar paquetes NuGet sin consultar primero.

## Reglas de trabajo con el agente

- Siempre responder en español.
- Antes de modificar cualquier archivo: proponer plan y esperar aprobación.
- Antes de instalar paquetes NuGet: preguntar y justificar.
- Antes de eliminar archivos: explicar motivo y pedir confirmación.
- Terminar cada tarea con dotnet build. Si hay tests, también dotnet test.
- Si algo no está claro, preguntar antes de asumir.

## Estilo de aprendizaje

Explicar cada paso con claridad antes de implementarlo.
Priorizar comprensión sobre velocidad.
Si un concepto es nuevo, incluir una explicación breve de por qué se hace así.

## Referencia

Proyecto principal de portfolio: github.com/ProgramEze/taskflow-pro-api
Ese proyecto puede consultarse como referencia de patrones y convenciones.
