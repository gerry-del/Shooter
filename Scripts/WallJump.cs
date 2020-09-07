using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController controller;

    [HideInInspector]
    public bool onWall = false;

    public float jumpSpeed;

    RaycastHit2D hit;
    public float rayDistance;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }


    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        hit = Physics2D.Raycast(transform.position, Vector3.right * transform.localScale.x, rayDistance);
        
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump") && !controller.isGrounded && hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            onWall = true;
            rb.velocity = new Vector2(jumpSpeed * hit.normal.x, jumpSpeed);

            if(transform.localScale.x == 1)
            {
                transform.localScale = new Vector2(-1, 1);
                controller.faceRight = false;
            }
            else if(transform.localScale.x == -1)
            {
                transform.localScale = Vector2.one;
                controller.faceRight = true;

            }
        }
    }

    public void OnDrawGizmos()  //para ver los gizmos en el editor y activarlos
    {
        Gizmos.color = Color.red;

        Debug.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * rayDistance);
    }
}
