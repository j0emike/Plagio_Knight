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

    void Start()
    {
        print("Start");
    }


    // Funciona mejor o peor dependiente de la PC
    void Update()
    {
        //transform ignora las fisicas
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Voy a la izquierda");
            transformPlayer.position = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            print("Voy a la derecha");
            transformPlayer.position = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            print("Voy hacia arriba");
            transformPlayer.position = Vector3.up;
        }
    }
}
