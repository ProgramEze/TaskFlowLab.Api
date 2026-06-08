# 06 - Log de aprendizaje

Errores encontrados, decisiones revisadas y cosas que conviene recordar.

---

## 2026-06-08 — Moq y FluentAssertions no se incluyen automáticamente

**Que paso:** El proyecto de tests compilaba bien con xUnit puro (módulo 3). Al agregar tests con mocks en el módulo 6, el build falló porque `Moq` y `FluentAssertions` no estaban en el `.csproj`.

**Solución:** Agregar los paquetes explícitamente en `TaskFlowLab.Tests.csproj`.

**Aprendizaje:** xUnit viene incluido en la plantilla de tests de .NET. Moq y FluentAssertions son paquetes separados que hay que agregar manualmente. Verificar el `.csproj` antes de escribir tests que usen mocks o assertions avanzadas.

---

## 2026-06-08 — Skill feature-brief: la skill explora el codebase sola

**Que paso:** Al invocar `/feature-brief` en Claude Code, el agente hizo 33 tool uses antes de generar el brief: exploró la estructura del proyecto, leyó entidades, repositorios y el controlador existente.

**Aprendizaje:** Una skill bien escrita no solo genera texto genérico — adapta la salida al estado real del proyecto. El brief resultante mencionó que no hay JWT todavía y propuso mecanismos provisionales acordes al código actual.

---

## 2026-06-08 — Parser aborted no significa error del archivo

**Que paso:** Claude Code mostró "Parser aborted (timeout, resource limit, or over-length)" al intentar mostrar el contenido del brief generado en pantalla. El archivo igual se creó correctamente.

**Aprendizaje:** El aviso es una limitación del display en terminal, no un error de escritura. Siempre verificar con `cat` o abriendo el archivo en el editor antes de asumir que falló.

---

## 2026-06-08 — Business OS: documentar decisiones antes de implementar

**Que paso:** Al cerrar el brief de comentarios, quedaron 3 preguntas abiertas de diseño (identificador de usuario, mecanismo de autorización, orden del listado) que el agente no podía resolver solo.

**Aprendizaje:** El valor del brief no es solo la especificación técnica — es forzar las decisiones de diseño *antes* de tocar código. Preguntas que parecen menores (¿query param o header?) afectan la firma de todos los endpoints.

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
