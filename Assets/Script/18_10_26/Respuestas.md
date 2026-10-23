# Respuestas de clase 06

## Ejercicios 1

1. ¿Por qué creamos una acción llamada **Move** en lugar de escribir cada tecla en script?
- Evitamos que el bilding dependenda de instrucciones declaradas sobre scripts perjudicando la escala del proyecto. 
- Permite configurar la misma acción sobre diferentes teclas y no depender de un solo bildiing.
- No integramos código innecesario sobre funciones determinadas y producimos scripts complejos. 

2. ¿Qué diferencia existe entre una acción y un bilding?
- El bilding es la forma en la que el usuario puede disparar la acción.

3. ¿Por qué move utiliza **Vector 2D**?
-  Porque Unity emplea ese modelo de desplaazamiento para mundos bidimensionales que permite mover los objetos por el eje "x" y "y". De ese modo, la estructura de datos es perfecta para definir posiciones, direcciones y velocidades sin arrastrar información innecesaria de un tercer eje.

3. ¿Qué ventaja tiene asignar WASD y las flechas a una misma acción?
- Permite a los jugadores disponer de diferentes formas de jugar sin depender de un solo modelo de bilding para hacer uso de las acciones en el juego.

4. Si quisieramos agregar un gamepad, ¿qué parte de la configuración podríamos ampliar?
- Entrar a PlayerControls -> Crear bilding -> Definir path acorde al gamepad.

## Ejercicio 2
1. ¿Qué función cumple onMove()?
- Comunicar al Player Input la acción realizada por los bildings programados para "Move".

2. ¿Por qué no utilizamos Input.GetKey()?
- No hacemos uso de los bilding por teclado porque lo sustituye la configuración hecha por Player Controls.

3. ¿Qué relación existe entre PlayerInput y MovimientoInput?
- El script (MovimientoInput) programa las acciones mientras que PlayerInput declara las bilding.  

4. ¿Qué ocurriría si el nombre de la acción fuera Movement y el método siguiera llamándose onMove?
- No funcionaría porque deben contener el mismo nombre, pues onMove es un prefijo para relacionar ambos métodos.

5. ¿Por qué podemos cambiar las teclas sin modificar el código?
- Esto debido a que PlayerControl contiene el bilding de forma aislada para no comprometer el código, siendo la principal característica de este método que facilita la escalabilidad de bilding sin depender de la sintaxis. 

## Ejercicio 3
1. ¿Qué diferencia existe entre el movimiento del ejercicio 2 y el ejercicio 3?
- El movimiento del ejercicio 2 se basa en la translación por coordenadas sin uso de físicas o reacciones de fuerza. Mientras que en este caso se aplica la física (fuerza e impulso) para llevar a cabo el movimiento del objeto.

2. ¿Por qué utilizamos FixedUpdate() para aplicar fuerzas?
- Se usa FixedUpdate()  para que la simulación física sea independiente de la velocidad de renderizado (FPS).

3. ¿Qué función cumple ForceMode2D.Impulse?
- ForceMode2D.Impulse permite brindarle una fuerza inmediata al objeto sin que sea gradual. 

4. ¿Por qué el cambio de color no necesita modificar el Rigidbody2D?
- No necesita cambiar el rigidbody debido a que el color representa una característica estética sin necesidad de depender de una reacción física.

5. ¿Qué ventaja tiene separar el movimiento y el cambio de color en scripts diferentes?
- Permite escalar las características de las mecánicas sin depender de un script único gracias al PlayerControl que permite asignar bilding y asignar acciones mediante scripts diferentes. 

## Reto final
1. ¿Qué diferencia existe entre una acción y un binding?
- Una acción es la ejecución de una instrucción disparada por el bilding (tecla) para que se ejecute.

2. ¿Por qué una acción Move puede utilizar varias distribuciones de teclas?
- Esto debido a que el mapeo que permite el bilding configurado por el Input System permite asignar diferentes modos para ejecutar acciones.

3. ¿Qué función cumple PlayerInput?
- PlayerInput facilita el mapeo de bildings (teclas) para disparar acciones gracias a los scripts que permiten relacionar el nombre del mapa con acciones.

4. ¿Qué relación existe entre OnMove y la acción Move?
- OnMove usa el prefijo "On" para relacionar el mapa con la acción declarada en el método con el mapa de bilding.

5. ¿Qué diferencia encontraste entre utilizar Transform y aplicar fuerzas?
- Transform aplica cambios en el gameObject para ser trasladada sobre coordenadas y  Rigidbody hace uso de la física para desplazar el gameObject.  

6. ¿Qué problema encontraste durante la migración?
- El principal problema a la hora de migrar fue implementar el cambio de método para relacionar los bilding con las funciones, pues demandan el uso de diferentes técnicas y convenciones para disparar las acciones acorde a la tecla utilizada.

7. ¿Cómo agregarías un gamepad a este sistema?
- Entrar a PlayerControls -> Crear bilding -> Definir path acorde al gamepad.

8. ¿Qué ventaja tendría separar los mapas de acciones de distintos estados del juego?
- Permite escalar las bildings disponibles sin comprometer los scripts. 