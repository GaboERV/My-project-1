using UnityEngine;

public class NaveEquilibrio : MonoBehaviour
{
    public float fuerza = 8f;
    public float velocidadEnderezado = 0.5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(
            horizontal * fuerza,
            vertical * fuerza
        );

        rb.AddForce(direccion * fuerza);

        float rotacionActual = rb.rotation;
        float rotacionSuavizada = Mathf.LerpAngle(rotacionActual, 0f, velocidadEnderezado * Time.fixedDeltaTime);
        rb.MoveRotation(rotacionSuavizada);
        rb.angularVelocity *= 0.5f; 
    }
}