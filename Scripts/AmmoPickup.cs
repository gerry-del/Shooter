using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    AudioSource myAudio;
    public AudioClip pickUpSound;

    public int ammoQty = 50;
    StatsManager stats;


    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsManager>();
        myAudio = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<AmmoManager>().ammo += ammoQty;
            stats.UpdateAmmo(col.GetComponent<AmmoManager>().ammo);
            col.GetComponent<AmmoManager>().haveAmmo = true;
            myAudio.PlayOneShot(pickUpSound);
            Destroy(gameObject);
        }
    }
}
