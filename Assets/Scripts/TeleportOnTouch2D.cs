using UnityEngine;

public class TeleportOnTouch2D : MonoBehaviour
{
    SimplePlayer player;
    [Header("Qué objetos activan el teletransporte")]
    public LayerMask triggerLayers;      // capas que provocan el teletransporte

    [Header("A dónde teletransportar")]
    public Transform respawnPoint;       // si está vacío, vuelve a la posición inicial

    Vector3 startPosition;
    Rigidbody2D rb;
    float startSpeed;
    Vector3 startScale;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<SimplePlayer>();   // el script está en este mismo objeto
        startSpeed = player.speed;               // dirección inicial (con su signo)
        startScale = transform.localScale;       // orientación inicial del sprite
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TryTeleport(collision.gameObject);
    }
    void Update()
    {
        if (player.rb.linearVelocity.x <= 0) { 
            TryTeleport(player.gameObject);
        }
    }
    void TryTeleport(GameObject other)
    {
        // Solo continúa si el otro objeto está en una capa elegida
        if ((triggerLayers.value & (1 << other.layer)) == 0) return;

        Vector3 destination = respawnPoint != null ? respawnPoint.position : startPosition;
        transform.position = destination;

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        // Restaurar dirección y orientación iniciales
        player.speed = startSpeed;
        transform.localScale = startScale;
    }
}
