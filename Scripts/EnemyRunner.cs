using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunner : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    [HideInInspector]
    public bool lookingRight = false;
    Rigidbody2D rb;
    public float lifeTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = lookingRight ? rb.velocity = Vector2.right * moveSpeed : rb.velocity = Vector2.left * moveSpeed;


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            rb.velocity = rb.velocity.x < 0 ? rb.velocity = Vector2.right * moveSpeed : rb.velocity = Vector2.left * moveSpeed;
            Flip();
        }
    }

    void Flip()
    {
        lookingRight = !lookingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
