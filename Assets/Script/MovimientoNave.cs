using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerza = 10f;
    public Rigidbody2D rigidBody2; 

    void Start(){
        rigidBody2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody2.AddForce(Vector2.left * fuerza * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody2.AddForce(Vector2.right * fuerza * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody2.AddForce(Vector2.up * fuerza * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody2.AddForce(Vector2.down * fuerza * Time.deltaTime);
        }
    }
}