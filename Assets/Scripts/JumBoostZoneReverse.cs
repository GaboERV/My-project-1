using UnityEngine;

public class JumBoostZoneReverse : MonoBehaviour
{
    public float boostForce = 14f;          // velocidad vertical del impulso
    public bool requireKeyPress = false;    // false: automático al entrar
                                            // true: hay que pulsar espacio dentro de la zona
    public bool flipSprite = true;          // gira también el aspecto del jugador

    SimplePlayer player;
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
        SimplePlayer found = other.GetComponentInParent<SimplePlayer>();
        if (found == null) return;

        player = found;
        target = other.attachedRigidbody;
        used = false;

        if (!requireKeyPress)
            Activate();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody == target)
        {
            target = null;
            player = null;
        }
    }

    void Update()
    {
        // Modo manual: una activación por cada entrada a la zona
        if (requireKeyPress && target != null && !used && Input.GetKeyDown(KeyCode.Space))
            Activate();
    }

    void Activate()
    {
        // 1) Impulso hacia arriba (igual que JumpBoostZone)
        target.linearVelocity = new Vector2(target.linearVelocity.x, boostForce);

        // 2) Invertir la dirección horizontal
        player.speed = -player.speed;

        if (flipSprite)
        {
            Vector3 scale = player.transform.localScale;
            player.transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }

        used = true;
    }
}