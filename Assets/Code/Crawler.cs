using UnityEngine;

public class Crawler : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float speed = 2f;
    public bool movingRight = true;
    [Header("Detecci�n")]
    public Transform groundCheck;
    public Transform wallCheck;
    public float checkDistanceX = 0.5f;
    public float checkDistanceY = 1f;
    public LayerMask layerMaskWall;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    //
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        // Operador ternario para direcci�n, primer valor si es true, segundo si es false
        float moveDir = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(moveDir * speed, rb.linearVelocity.y);

        // Detectar pared y falta de suelo
        bool hitWall = Physics.Raycast(wallCheck.position, movingRight ? Vector2.right : Vector2.left, checkDistanceX, layerMaskWall);
        bool noGround = !Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistanceY, layerMaskWall);

        // Cambiar direcci�n
        if (hitWall || noGround)
        {
            Flip();
        }
    }

    private void Update()
    {
        // Debug Rays
        Debug.DrawRay(wallCheck.position, (movingRight ? Vector2.right : Vector2.left) * checkDistanceX, Color.red);
        //CircleCast
        Debug.DrawRay(groundCheck.position, Vector2.down * checkDistanceY, Color.blue);

    }

    void Flip()
    {
        Debug.Log("Flip");
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Detener el movimiento horizontal antes de girar
        movingRight = !movingRight;
        // Invierte solo el sprite (no el transform completo)
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}