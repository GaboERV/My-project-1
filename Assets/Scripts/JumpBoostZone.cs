using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class JumpBoostZone : MonoBehaviour
{
    public float boostForce = 14f;          // velocidad vertical del impulso
    public bool requireKeyPress = false;    // false: impulso automático al entrar
                                            // true: hay que pulsar espacio dentro de la zona

    Rigidbody2D target;
    bool used;

    void Reset()
    {
        // Al añadir el script, deja el collider como trigger (atravesable)
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Solo reacciona al jugador
        if (other.GetComponentInParent<SimplePlayer>() == null) return;

        target = other.attachedRigidbody;
        used = false;

        if (!requireKeyPress)
            Boost();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody == target)
            target = null;
    }

    void Update()
    {
        // Modo manual: un impulso por cada entrada a la zona
        if (requireKeyPress && target != null && !used && Input.GetKeyDown(KeyCode.Space))
            Boost();
    }

    void Boost()
    {
        target.linearVelocity = new Vector2(target.linearVelocity.x, boostForce);
        used = true;
    }
}
