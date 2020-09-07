using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    Animator myAnim;
    public float shootingRate;
    float count;

    public Transform bulletSpanner;
    public Transform diagSpanner;
    public Transform verticalSpanner;
    public GameObject bulletPrefab;
    public Transform crouchSpanner;

    PlayerController controller;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        
    }


    void Update()
    {
        PlayerShooting();
    }

    void PlayerShooting()
    {
        if (Input.GetButton("Fire1") && GetComponent<AmmoManager>().haveAmmo)
        {
            count += Time.deltaTime;
            if(count >= shootingRate)
            {
                if (!controller.diagLook && !controller.verticalLook && !controller.crouching)
                {
                    Instantiate(bulletPrefab, bulletSpanner.position, Quaternion.identity);
                    myAnim.SetBool("Shooting", true);
                }
                else if (controller.diagLook && !controller.verticalLook && !controller.crouching)
                {
                    Instantiate(bulletPrefab, diagSpanner.position, Quaternion.identity);
                    myAnim.SetBool("Shooting", false);
                }
                else if(!controller.diagLook && controller.verticalLook && !controller.crouching)
                {
                    Instantiate(bulletPrefab, verticalSpanner.position, Quaternion.identity);
                }
                else if(!controller.diagLook && !controller.verticalLook && controller.crouching)
                {
                    Instantiate(bulletPrefab, crouchSpanner.position, Quaternion.identity);

                }

                GetComponent<AmmoManager>().UseAmmo();
                count = 0;
            }
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            myAnim.SetBool("Shooting", false);
        }
    }
}
