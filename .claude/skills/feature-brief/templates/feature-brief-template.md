# Brief tecnico - [Nombre de la feature]

Fecha: YYYY-MM-DD
Estado: Borrador
Modulo: [Auth / Workspaces / Projects / Tasks / Comments / Notifications]

## 1. Resumen

Explicar en 3 a 5 lineas que se quiere construir.

## 2. Problema que resuelve

Explicar que necesidad del usuario o del sistema se cubre.

## 3. Alcance incluido

- Punto incluido 1.
- Punto incluido 2.
- Punto incluido 3.

## 4. Alcance excluido

- Punto que NO se implementa todavia.
- Punto que queda para otra iteracion.

## 5. Reglas de negocio

- Regla 1.
- Regla 2.
- Regla 3.

## 6. Impacto por capa

### Domain
- Entidades o enums afectados.

### Application
- Servicios, DTOs, validaciones y casos de uso.

### Infrastructure
- Repositorios, DbContext, migraciones o consultas.

### Api
- Controllers, endpoints, autenticacion y autorizacion.

## 7. Endpoints propuestos

| Metodo | Ruta | Descripcion | Auth |
|--------|------|-------------|------|
| POST | /api/... | Crear recurso | Si |

## 8. DTOs necesarios

- `NombreRequest` — campos y validaciones.
- `NombreResponse` — campos devueltos.

## 9. Tests recomendados

- Unit tests sobre reglas de negocio.
- Integration tests sobre endpoints principales.
- Casos de error y permisos.

## 10. Riesgos tecnicos

- Riesgo 1.
- Riesgo 2.

## 11. Preguntas abiertas

- Pregunta 1.
- Pregunta 2.

## 12. Checklist antes de implementar

- [ ] El alcance esta claro.
- [ ] Las reglas de negocio estan escritas.
- [ ] Los endpoints tienen metodo y ruta.
- [ ] Hay tests previstos.
- [ ] No se tocaran secretos ni archivos .env.
