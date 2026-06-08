# 06 - Log de aprendizaje

Errores encontrados, decisiones revisadas y cosas que conviene recordar.

---

## 2026-06-07 — settings.json no acepta comentarios JavaScript

**Que paso:** El archivo `.claude/settings.json` tenia comentarios estilo `//` que son invalidos en JSON estandar. Claude Code fallaba al parsear los permisos.

**Solucion:** Eliminar todos los comentarios del JSON. Usar nombres descriptivos en las reglas para que sean autoexplicativas.

**Aprendizaje:** JSON puro, sin comentarios. Si necesitas documentar una regla, hacelo en un archivo `.md` separado.

---

## 2026-06-07 — Flag incorrecto en git worktree

**Que paso:** El video del curso usa `--wktree` como flag, pero el flag correcto es `--worktree`.

**Solucion:** Verificar siempre los flags con `git worktree --help` antes de ejecutar.

**Aprendizaje:** Los videos pueden tener errores tipograficos en comandos. Siempre contrastar con la documentacion oficial.

---

## 2026-06-07 — ConcurrentDictionary en repositorio Singleton

**Que paso:** El repositorio en memoria estaba registrado como Singleton. Usar `Dictionary<>` normal no es thread-safe en ese contexto.

**Solucion:** Reemplazar por `ConcurrentDictionary<>` para garantizar seguridad en accesos concurrentes.

**Aprendizaje:** El lifetime del servicio determina el tipo de coleccion a usar. Singleton + estado compartido = siempre thread-safe.
