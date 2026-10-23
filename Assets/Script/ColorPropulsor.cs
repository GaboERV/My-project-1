using UnityEngine;

public class ColorPropulsor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 
    [Header("Sprites del Propulsor")]
    [Tooltip("Sprite 10: Fuego mínimo / Reposo")]
    public Sprite spriteReposo;

    [Tooltip("Sprite 1: Fuego máximo / En movimiento")]
    public Sprite spriteMovimiento;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteReposo != null)
        {
            spriteRenderer.sprite = spriteReposo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona alguna flecha de movimiento
        bool seEstaMoviendo = Input.GetKey(KeyCode.LeftArrow) ||
                             Input.GetKey(KeyCode.RightArrow) ||
                             Input.GetKey(KeyCode.UpArrow) ||
                             Input.GetKey(KeyCode.DownArrow);
        // Cambia el sprite según el estado
        if (seEstaMoviendo)
        {
            spriteRenderer.sprite = spriteMovimiento;
        }
        else
        {
            spriteRenderer.sprite = spriteReposo;
        }
    }
}
