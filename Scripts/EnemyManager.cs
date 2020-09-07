using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int health = 5;
    public int enemyValue = 200;

    public GameObject enemyExplosion;
    AudioSource sound;
    public AudioClip destroyedSFX;

    [HideInInspector]
    public bool enemyDead = false;

    StatsManager stats;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>();
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsManager>();


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            health -= col.GetComponent<BulletManager>().damgeValue;
            Destroy(col.gameObject);

            if (health <= 0)
            {
                Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                sound.PlayOneShot(destroyedSFX);

                stats.UpdateScore(enemyValue);

                Destroy(gameObject);
            }
        }
    }
}
