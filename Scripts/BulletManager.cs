using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    Rigidbody2D rb;

    PlayerController player;

    public int damgeValue = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (player.faceRight && !player.diagLook && !player.verticalLook)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
        else if (!player.faceRight && !player.diagLook && !player.verticalLook)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (player.faceRight && player.diagLook && !player.verticalLook)
        {
            rb.velocity = new Vector2(speed, speed);
        }
        else if (!player.faceRight && player.diagLook && !player.verticalLook)
        {
            rb.velocity = new Vector2(-speed, speed);
        }
        else if (!player.diagLook && player.verticalLook)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }



        Destroy(gameObject, lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
