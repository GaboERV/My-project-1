using UnityEngine;

public class ControlPelotaPong : MonoBehaviour
{
    public float velocidadInicial = 6f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Se llama a una función para lanzar la pelota al iniciar
        LanzarPelota();
    }

    void LanzarPelota()
    {
        // Elegimos de forma aleatoria si va hacia la izquierda (-1) o hacia la derecha (1)
        float direccionX = Random.Range(0, 2) == 0 ? -1f : 1f;
        
        // Elegimos una dirección vertical aleatoria moderada para que no salga totalmente horizontal
        float direccionY = Random.Range(-0.5f, 0.5f);

        // Creamos el vector de dirección y lo normalizamos para mantener constante
        Vector2 direccion = new Vector2(direccionX, direccionY).normalized;

        // Se asigna la velocidad inicial
        rb.linearVelocity = direccion * velocidadInicial;
    }

    public void ReiniciarPelota()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;

        Invoke("LanzarPelota", 1.5f);
    }
}