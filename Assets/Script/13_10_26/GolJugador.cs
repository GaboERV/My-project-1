using UnityEngine;

public class ZonaGol : MonoBehaviour
{

    public bool esGolJugador1;  

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el objeto que entró es la pelota (puedes asegurarte de ponerle la etiqueta "Pelota" a tu pelota)
        if (collision.CompareTag("Pelota"))
        {
            if (esGolJugador1)
            {
                Debug.Log("¡Punto para el Jugador 1!");
            }
            else
            {
                Debug.Log("¡Punto para el Jugador 2!");
            }

            // Reinicia la posición de la pelota al centro (0,0) y la detenemos un momento
            Rigidbody2D rbPelota = collision.GetComponent<Rigidbody2D>();
            rbPelota.linearVelocity = Vector2.zero;
            collision.transform.position = Vector3.zero;

            ControlPelotaPong scriptPelota = collision.GetComponent<ControlPelotaPong>();

            scriptPelota.ReiniciarPelota();
        }
    }
}