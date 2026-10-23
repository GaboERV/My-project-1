using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    [Header("Colores por Dirección")]
    public Color colorNeutro = Color.white;
    public Color colorArriba = Color.green;
    public Color colorAbajo = Color.red;
    public Color colorIzquierda = Color.yellow;
    public Color colorDerecha = Color.cyan;

    private SpriteRenderer spriteRenderer;

    void Awake() { spriteRenderer = GetComponent<SpriteRenderer>(); }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) spriteRenderer.color = colorArriba;
        else if (Input.GetKey(KeyCode.DownArrow)) spriteRenderer.color = colorAbajo;
        else if (Input.GetKey(KeyCode.LeftArrow)) spriteRenderer.color = colorIzquierda;
        else if (Input.GetKey(KeyCode.RightArrow)) spriteRenderer.color = colorDerecha;
        else spriteRenderer.color = colorNeutro;
    }
}
