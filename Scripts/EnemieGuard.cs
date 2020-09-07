using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieGuard : MonoBehaviour
{
    public LayerMask target;
    public bool targetLocated = false;
    public float vision = 1.5f;

    AudioSource enemySound;
    public AudioClip shootingSE;

    public Transform bulletSpanner;
    public GameObject bullet;
    public float firingRate = 0.3f;
    float mainTimer;
    public float shootingLapse = 1f;
    private bool shotsFired = false;
    float count;
    public int shotCount = 0;

    Animator eAnim;

    public bool lookingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        eAnim = GetComponent<Animator>();
        enemySound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        targetLocated = Physics2D.OverlapCircle(transform.position, vision, target);

        if (targetLocated)
        {
            Attack();
        }
        else
        {
            eAnim.SetBool("Shooting", false);
            shotCount = 0;
            mainTimer = 0;
            count = 0;
        }
    }

    void Attack()
    {
        mainTimer += Time.deltaTime;

        if(mainTimer>= shootingLapse)
        {
            count += Time.deltaTime;

            if(count >= firingRate && shotCount < 3)
            {
                eAnim.SetBool("Shooting", true);
                GameObject newBullet = Instantiate(bullet, bulletSpanner.position, Quaternion.identity);
                newBullet.GetComponent<EnemyBulletManager>().lookingRight = lookingRight;

                shotCount++;
                enemySound.PlayOneShot(shootingSE);

                count = 0;
            }
            else if(count>= firingRate && shotCount >= 3)
            {
                mainTimer = 0;
                shotCount = 0;
                eAnim.SetBool("Shooting", false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
