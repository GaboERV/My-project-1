using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RespawnWhenStopped : MonoBehaviour
{
    public float stopDelay = 0.3f;        // segundos detenido antes de reaparecer
    public float stopThreshold = 0.05f;   // por debajo de esta velocidad en X cuenta como detenido

    Rigidbody2D rb;
    SimplePlayer player;                  // opcional: para restaurar la dirección inicial
    Vector3 startPosition;
    Vector3 startScale;
    float startSpeed;
    float stoppedTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        startScale = transform.localScale;

        // Si el objeto tiene SimplePlayer, guarda su dirección inicial
        if (TryGetComponent(out player))
            startSpeed = player.speed;
    }

    void FixedUpdate()
    {
        // Abs: funciona también si la dirección está invertida (speed negativo)
        if (Mathf.Abs(rb.linearVelocity.x) < stopThreshold)
        {
            stoppedTimer += Time.fixedDeltaTime;
            if (stoppedTimer >= stopDelay)
                Respawn();
        }
        else
        {
            stoppedTimer = 0f;
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        transform.localScale = startScale;

        if (player != null)
            player.speed = startSpeed;

        stoppedTimer = 0f;
    }
}
