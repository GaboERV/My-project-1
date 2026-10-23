# Documentación del Reto Final: Migración al New Input System

## 1. Resumen de la Implementación
Se completó la migración de la escena de equilibrio de la nave y la pelota, sustituyendo el sistema clásico de inputs (`Input.GetKey`, `Input.GetAxisRaw`) por el **New Input System** (`PlayerInput`, `.inputactions`).

### Objetos y Configuración en la Escena (`Reto_Input_Equilibrio.unity`):
* **Nave:**
  * Posición: `(0, -1, 0)` | Escala: `(3, 0.5, 1)`
  * Componentes: `SpriteRenderer`, `BoxCollider2D`, `Rigidbody2D` (Dynamic, Gravity Scale = 0, Linear Damping ajustado para mejor control).
  * Scripts: `NaveInput.cs` (control con `AddForce`), `CambioColorInput.cs` (cambio alternativo de color al recibir acción `ChangeColor`).
  * `PlayerInput`: Actions = `PlayerControls`, Default Map = `Player`, Behavior = `Send Messages`.
* **Pelota:**
  * Posición: `(0, 0, 0)` | Escala: `(0.5, 0.5, 1)`
  * Componentes: `SpriteRenderer`, `CircleCollider2D`, `Rigidbody2D` (Dynamic, Gravity Scale = 1).
  * Script: `PelotaInput.cs` (impulso vertical con `ForceMode2D.Impulse` y detección de colisión con `"Suelo"`).
  * `PlayerInput`: Actions = `PlayerControls`, Default Map = `Player`, Behavior = `Send Messages`.
* **Suelo:**
  * Posición: `(0, -4, 0)` | Escala: `(14, 1, 1)`
  * Componentes: `SpriteRenderer`, `BoxCollider2D` (Estático, sin Rigidbody2D).

---

## 2. Acciones y Mapeo en `PlayerControls.inputactions`
* **Move** (`Value`, `Vector2`): Mapeado con 2D Composite a:
  * **WASD**: `<Keyboard>/w`, `<Keyboard>/a`, `<Keyboard>/s`, `<Keyboard>/d`
  * **Flechas de dirección**: `<Keyboard>/upArrow`, `<Keyboard>/downArrow`, `<Keyboard>/leftArrow`, `<Keyboard>/rightArrow`
* **Jump** (`Button`): Mapeado a `<Keyboard>/space`.
* **ChangeColor** (`Button`): Mapeado a `<Keyboard>/c`.

---

## 3. Registro de Pruebas Físicas (Mínimo 3 configuraciones)

| Configuración | Fuerza Nave (`fuerza`) | Impulso Pelota (`fuerzaImpulso`) | Gravedad Pelota (`gravityScale`) | Resultado Observado |
| :--- | :--- | :--- | :--- | :--- |
| **Prueba 1: Valores base** | `8f` | `4f` | `1.0` | La nave responde de forma suave, pero ante movimientos bruscos la pelota desliza rápido hacia los bordes. El salto con espacio levanta la pelota lo justo para reacomodar la nave debajo. |
| **Prueba 2: Fuerza excesiva** | `18f` | `8f` | `1.0` | La nave acelera demasiado rápido por inercia física, haciendo que la pelota salga disparada lateralmente por fricción/reacción, siendo casi imposible mantener el equilibrio. |
| **Prueba 3: Configuración equilibrada (Recomendada)** | `10f` - `12f` | `4.5f` | `0.85` | Al reducir ligeramente la gravedad y mantener una fuerza moderada en la nave, la pelota tiene mayor tiempo en el aire y un descenso predecible, permitiendo maniobrar y mantenerla en equilibrio de forma fluida. |

---

## 4. Detección de Caída
Al caer la pelota sobre el objeto **Suelo**, `OnCollisionEnter2D` en `PelotaInput.cs` evalúa `collision.gameObject.name == "Suelo"` e imprime en la consola de Unity:
```text
La pelota cayó al suelo.
```

---

## 5. Comparación: New Input System vs Sistema Clásico

| Criterio | New Input System (`UnityEngine.InputSystem`) | Sistema Clásico (`UnityEngine.Input`) |
| :--- | :--- | :--- |
| **Acoplamiento de código** | **Desacoplado:** El script sólo escucha nombres de acciones (`OnMove`, `OnJump`). No conoce qué teclas o dispositivos disparan la acción. | **Acoplado:** El código contiene directamente `KeyCode.Space`, `"Horizontal"`, etc. |
| **Soporte Multi-dispositivo** | Nativo para Gamepads (Xbox, PlayStation, Switch), teclados, ratones, pantallas táctiles y sensores mediante binding visual. | Requiere condicionales manuales o mapeo tedioso en el `InputManager` de ProjectSettings. |
| **Revinculación (Rebinding)** | Soporta remapeo dinámico de teclas en tiempo de ejecución por el usuario con APIs nativas. | Extremadamente complejo de implementar dinámicamente en menús de opciones. |
| **Modo de ejecución** | Basado en eventos y callbacks (`Send Messages`, `Invoke Unity Events`, `C# Events`), ahorrando comprobaciones `if` continuas en cada `Update`. | Requiere chequear `Input.GetKeyDown()` continuamente en el bucle `Update()`. |
