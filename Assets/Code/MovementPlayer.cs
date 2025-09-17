///
/// Made by j0emike
/// Script para movimiento del jugador
/// 
///

//Librerias - Funciones prestadas de otros scripts
using UnityEngine;

//Public - Da permiso de usar su informacion
     //class - forma de declararla
           //MovementPlayer - Nombre del Script
                          //: - Herencia entre la clase y la clase que le hereda  
public class MovementPlayer : MonoBehaviour
{
    public Transform transformPlayer;
    public Rigidbody2D rigidBody2DPlayer;
    public SpriteRenderer spriteRenderer;
    public bool saltoValido = true;
    public float fuerzaSalto = 7f;

    void Start()
    {
        print("Start");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            print("Voy a la izquierda");
            rigidBody2DPlayer.AddForce(Vector2.left * 5f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Voy a la derecha");
            rigidBody2DPlayer.AddForce(Vector2.right * 5f);
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            print("Estoy saltando");
            if (saltoValido)
            {
                rigidBody2DPlayer.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                saltoValido = false; 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            saltoValido = true;
        }
    }
}
