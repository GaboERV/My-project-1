using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;

    [Header("Salto")]
    public float jumpForce = 14f;       // es una VELOCIDAD, no una fuerza: 10-20 es lo normal
    public LayerMask groundLayer;       // capa(s) que cuentan como suelo

    [Header("Gravedad")]
    public float riseGravity = 2f;      // gravedad al subir con espacio pulsado
    public float fallGravity = 5f;      // gravedad al caer o al soltar espacio
    public Vector3 startPosition;

    public Rigidbody2D rb;
    SpriteRenderer sp;
    bool grounded;
    public float stopDelay = 0.3f;   // segundos detenido antes de reaparecer
    float stoppedTimer;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // GetKey: si mantienes espacio, vuelve a saltar en cuanto toca el suelo
        // (la comprobación de velocidad evita un doble salto justo al despegar)
        if (Input.GetKey(KeyCode.Space) && grounded && rb.linearVelocity.y <= 0.01f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            sp.color = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.8f, 1f);
            grounded = false;
        }

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        float vy = rb.linearVelocity.y;
        bool holding = Input.GetKey(KeyCode.Space);

        if (vy < 0f)
            rb.gravityScale = fallGravity;      // cayendo
        else if (vy > 0f && !holding)
            rb.gravityScale = fallGravity;      // soltó espacio: salto más corto
        else
            rb.gravityScale = riseGravity;      // subiendo con espacio pulsado: salto completo

        // Se vuelve a poner en true en OnCollisionStay2D si sigue tocando el suelo
        grounded = false;
        if (Mathf.Abs(rb.linearVelocity.x) <= 0.05f)
        {
            stoppedTimer += Time.fixedDeltaTime;
            if (stoppedTimer >= stopDelay)
                transform.position = startPosition;
        }
        else
        {
            stoppedTimer = 0f;
        }
    }

    void OnCollisionStay2D(Collision2D c)
    {
        // Solo cuenta si el objeto está en la capa de suelo
        if ((groundLayer.value & (1 << c.gameObject.layer)) == 0) return;

        // Y si el contacto es por debajo (así las paredes no cuentan)
        foreach (ContactPoint2D contact in c.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                grounded = true;
                return;
            }
        }
    }
}