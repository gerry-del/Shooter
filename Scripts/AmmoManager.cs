using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public int ammo = 50;
    StatsManager stats;

    public bool haveAmmo = true;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsManager>();
        stats.UpdateAmmo(ammo);
    }
    
    public void UseAmmo()
    {
        ammo--;

        if(ammo <= 0)
        {
            ammo = 0;
            haveAmmo = false;
        }
        stats.UpdateAmmo(ammo);
    }
}
