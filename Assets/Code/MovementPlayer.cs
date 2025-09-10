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
    //Variables
    public Transform transformPlayer;
    public Rigidbody2D rigidBody2DPlayer;
    public SpriteRenderer spriteRenderer;
    public bool saltoValido = true;

    void Start()
    {
        print("Start");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Funciona mejor o peor dependiente de la PC
    void Update()
    {
        //transform ignora las fisicas
        
        if (Input.GetKey(KeyCode.A))
        {
            print("Voy a la izquierda");
            rigidBody2DPlayer.AddForce(Vector2.left * 5f);
            //transformPlayer.position = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Voy a la derecha");
            rigidBody2DPlayer.AddForce(Vector2.right * 5f);
            //transformPlayer.position = Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            print("Voy hacia arriba");
            if (saltoValido)
            {
                rigidBody2DPlayer.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);
            }
            //transformPlayer.position = Vector3.up;
        }
        
    }

    //Detecta una Colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
