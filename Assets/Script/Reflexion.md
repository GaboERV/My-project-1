# Reflexión final

1. ¿En qué se diferencia Transform.Translate() de Rigidbody2D.AddForce()?
- Translate hace uso de coordenadas para mover gameobjects de un punto a otro sin necesidad de que dependa de físicas cruciales como gravedad, fuerza o resistencia. Su movimiento es estático en el contexto de los puntos que se basan las coordenadas y no reactivos por otras fuerzas. En cambio, Rigidbody concentra el movimiento de sus objetos por fuerza, permitiendo que se interactúe con la física del juego y de otros objetos.   

2. ¿Qué diferencia hay entre aplicar un impulso y asignar linearVelocity?
- Un impulso consiste en un movimiento en seco que no depende de una velocidad constante o lineal. En cambio linearVelocity permite hacer uso de una velocidad constante y lineal.

3. ¿Qué papel desempeña la gravedad?
- La gravedad es una fuerza que simula la atracción de los elementos como sucede en el mundo real. Gracias a esta característica es posible generar fuerzas de atracción y ajustarla a las necesidades de la mecánica: hacer objetos más pesados o que funcionan de forma contraria a la gravedad.

4. ¿Por qué necesitamos colliders para detectar contactos físicos?
- Los colliders son necesarios porque permiten disparar eventos una vez se entre en contacto entre objetos, además de delimitar la zona de juego para elementos que necesiten un comportamiento controlado en un rango específico.

5. ¿Qué propiedad modificaste para mejorar el equilibrio?
- Para mejorar el equilibrio de la nave tuve que ajustar las masas de los objetos debido a que es primordial para que la pelota no sea más pesada que la plataforma, y esta última pueda soportar su peso. Además, tuve que recurrir a un método matemático que ofrece Unity para ajustar la corrección de inclinación y lograr que la plataforma no se vea comprometida por la gravedad de la pelota. Si bien la plataforma podía soportar su peso, no podía ajustarse a la inclinación provocando que la pelota siguiera siendo atraída por la gravedad.  

6. ¿Qué problema encontraste durante las pruebas y cómo lo resolviste?
- La masa de la plataforma comprometía la velocidad de la misma, haciendo que tuviera que ajustar la fuerza para obtener una mejor velocidad y reacción. 

7. Si tuvieras que construir un proyectil, ¿qué técnica elegirías y por qué?
- Idealmente es haciendo uso de Rigidbody con el método addforce para que el proyectil pueda interactuar con el entorno y depender de las físicas. Si tuvieramos un juego cuya mecánica se basa en disparar proyectiles a una torre de cajas, este método permite que los proyectiles interactúen con las mismas para dar como resultado una consecuencia basada en la física. 

8. ¿Qué cambiarías si quisieras una nave que se desplazara de manera más controlada y sin inercia?
- Ajustaría el linear damping para que se vea afectada por la resistencia y una masa más ajustada para que el movimiento se sienta pesado y no tan agresivo.  