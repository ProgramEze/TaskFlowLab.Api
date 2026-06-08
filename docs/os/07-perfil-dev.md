# 07 - Perfil de desarrollo

## Objetivo

Estoy construyendo TaskFlowLab.Api como laboratorio backend para practicar arquitectura, integraciones externas, seguridad, testing y despliegue. El proyecto toma TaskFlow Pro API como referencia pero se construye desde cero, paso a paso, entendiendo cada decision antes de automatizarla.

## Nivel esperado de ayuda

Explicar las decisiones antes de implementarlas. Priorizar codigo claro, pruebas automatizadas y seguridad por encima de velocidad.

## Stack principal

- Lenguaje: C# (.NET 8)
- Framework: ASP.NET Core 8
- ORM: Entity Framework Core
- Base de datos: PostgreSQL
- Autenticacion: JWT
- Testing: xUnit
- Contenedores: Docker
- CI/CD: GitHub Actions

## Forma de trabajo

1. Analizar el codigo existente antes de proponer cambios.
2. Proponer plan y archivos a tocar.
3. Esperar aprobacion explicita.
4. Implementar cambios pequenos, una capa a la vez.
5. Ejecutar build y tests despues de cada cambio.
6. Resumir que cambio y que falta.

## Convenciones

- Todo el codigo en espanol: clases, metodos, propiedades, variables, interfaces, enums, commits y comentarios.
- Solo los nombres de frameworks y paquetes externos quedan en ingles.
- Nunca leer ni modificar `.env`, `secrets/`, `credentials/` ni archivos `*.pem`.
