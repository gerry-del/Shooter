using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    public float bulletSpeed = 15f;
    Rigidbody2D rb;
    public int damageValue;
    public bool lookingRight;
    public float lifeTime = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = lookingRight ? Vector2.right * bulletSpeed : Vector2.left * bulletSpeed;

        Destroy(gameObject, lifeTime);
    }

}
