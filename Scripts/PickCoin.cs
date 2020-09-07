using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoin : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rb;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * jumpForce;

        Destroy(gameObject, lifeTime);
    }


}
