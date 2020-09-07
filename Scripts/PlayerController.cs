using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    //velocidad que el jugador tiene cuando se mueve
    public float moveSpeed = 2500f;
    //eljugador mira a la derecha en cuanto empieza el juego
    public bool faceRight = true;

    //referencia al animador
    Animator myAnim;

    //variables para el salto
    public Transform groundCheck;
    public float checkRadius = 0.05f;
    public LayerMask whatIsGround;
    [HideInInspector]
    public bool isGrounded;
    public float jumpForce = 55f;

    [HideInInspector]
    public bool diagLook = false;
    [HideInInspector]
    public bool verticalLook = false;
    [HideInInspector]
    public bool crouching = false;

    WallJump wallJump;

    void Start()
    {
        //Referencia al componente rigidbody del jugador
        rb = GetComponent<Rigidbody2D>();

        //referencia al animador del jugador
        myAnim = GetComponent<Animator>();

        //Para que salte sobre la pared
        wallJump = GetComponent<WallJump>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        myAnim.SetBool("grounded", isGrounded);

    }

    void Update()
    {

        PlayerMovement();
        PlayerJump();

    }

    void PlayerMovement()
    {
        //Para mover horizontal al jugador con input horizontal multiplicando la velocidad del movimiento para crear un valor global en la variable move
        float move = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical");

        // para que el jugador se mueva
        rb.velocity = new Vector2(move, rb.velocity.y);

        if(move>0 && !faceRight || move<0 && faceRight)
        {
            FlipPlayer();
        }
        else if (Mathf.Abs(move)>0 && vertical>0 && isGrounded)
        {
            diagLook = true;
            verticalLook = false;
            myAnim.SetBool("ShootingDiag", true);
            myAnim.SetBool("VerticalLook", false);
            myAnim.SetBool("Crouching", false);

        }
        else if(move == 0 && vertical>0 && isGrounded)
        {
            verticalLook = true;
            diagLook = false;
            myAnim.SetBool("VerticalLook", true);
            myAnim.SetBool("ShootingDiag", false);
            myAnim.SetBool("Crouching", false);
        }
        else if(move==0 && vertical<0 && isGrounded)
        {
            crouching = true;
            verticalLook = false;
            diagLook = false;
            myAnim.SetBool("ShootingDiag", false);
            myAnim.SetBool("VerticalLook", false);
            myAnim.SetBool("Crouching", true);
        }
        else if(Mathf.Abs(move) <= 0 || vertical == 0)      //(vertical <=0 && isGrounded)
        {
            diagLook = false;
            verticalLook = false;
            crouching = false;
            myAnim.SetBool("ShootingDiag", false);
            myAnim.SetBool("VerticalLook", false);
            myAnim.SetBool("Crouching", false);
        }
        myAnim.SetFloat("Speed", Mathf.Abs(move));
    }

    void FlipPlayer()
    {
        //cambia el valor opuesto para que gire el jugador
        faceRight = !faceRight;
        Vector3 curScale = transform.localScale;

        curScale.x *= -1;

        transform.localScale = curScale;
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        myAnim.SetFloat("vSpeed", rb.velocity.y);
    }
}


