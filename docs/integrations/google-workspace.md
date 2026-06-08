# Integracion futura: Google Workspace

## Estado

No implementada. Existe una implementacion nula (`NullServicioAutomatizacionWorkspace`) que permite compilar y testear sin credenciales reales.

## Objetivo futuro

Exportar resumenes del proyecto a Google Docs o Google Sheets sin que Domain conozca Google Workspace.

## Arquitectura esperada

```
Application  →  IServicioAutomatizacionWorkspace  (interfaz)
Infrastructure →  NullServicioAutomatizacionWorkspace  (hoy)
               →  GoogleWorkspaceServicio  (cuando se implemente)
Api          →  GET /api/integraciones/workspace/estado  (diagnostico)
```

## Reglas de seguridad

- No guardar credenciales en Git.
- No usar cuentas personales para pruebas publicas.
- No pedir scopes amplios si no hacen falta.
- No exponer contenido de Drive, Gmail o Calendar desde endpoints publicos.
- Credenciales van en variables de entorno o `appsettings.Development.json` local (no versionado).

## Scopes minimos previstos

| Operacion | Scope necesario |
|-----------|----------------|
| Exportar a Google Docs | `https://www.googleapis.com/auth/documents` |
| Exportar a Google Sheets | `https://www.googleapis.com/auth/spreadsheets` |

## Archivos sensibles a proteger

```
credentials/google-oauth-client.json   # NO versionar
credentials/google-token-cache.json    # NO versionar
client_secret*.json                    # NO versionar
token*.json                            # NO versionar
```
