using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanner : MonoBehaviour
{
    public float triggerRaidius;
    public LayerMask target;
    bool targetLocated = false;
    AudioSource doorAudio;
    public AudioClip alarmSFX;
    bool alarmActive = false;
    public GameObject enemy;
    public float spawnRate = 1f;
    public int maxEnemiesSpawne = 10;
    float count;
    public int health = 4;
    public int valor = 400;
    SpriteRenderer doorImage;
    public GameObject enemyExplotion;

    StatsManager stats;

    void Start()
    {
        doorAudio = GetComponent<AudioSource>();
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsManager>();

        doorImage = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        targetLocated = Physics2D.OverlapCircle(transform.position, triggerRaidius, target);
        if (targetLocated)
        {
            doorAudio.clip = alarmSFX;
            doorAudio.loop = true;

            if (!alarmActive)
            {
                doorAudio.Play();
                alarmActive = true;
            }
        }
        
    }

    void Update()
    {
        if (targetLocated)
        {
            count += Time.deltaTime;
            if(count>= spawnRate && maxEnemiesSpawne > 0)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);

                maxEnemiesSpawne--;
                count = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            health -= col.GetComponent<BulletManager>().damgeValue;

            if (health < 0)
            {
                Instantiate(enemyExplotion, transform.position, Quaternion.identity);

                Destroy(gameObject);
                health = 0;

                stats.UpdateScore(valor);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRaidius);
    }
}
