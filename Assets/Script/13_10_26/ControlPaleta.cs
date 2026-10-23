using UnityEngine;

public class ControlPaleta : MonoBehaviour
{
    public float velocidad = 8f;
    
    // Podemos elegir qué teclas usará la paleta 
    public KeyCode teclaArriba = KeyCode.W;
    public KeyCode teclaAbajo = KeyCode.S;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
            
    }

    void FixedUpdate()
    {
        float direccionVertical = 0f;

        // Si se presiona la tecla de arriba, nos movemos hacia arriba (1)
        if (Input.GetKey(teclaArriba))
        {
            direccionVertical = 1f;
        }
        // Si se presiona la tecla de abajo, nos movemos hacia abajo (-1)
        else if (Input.GetKey(teclaAbajo))
        {
            direccionVertical = -1f;
        }

        // Aplica la velocidad vertical usando linearVelocity
        rb.linearVelocity = new Vector2(0f, direccionVertical * velocidad);
    }
}