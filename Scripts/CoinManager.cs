using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coinValue = 100;
    public int coinCount;

    StatsManager stats;
    public GameObject pickCoin;


    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            stats.UpdateScore(coinValue);
            stats.UpdateCoin(coinCount);

            Instantiate(pickCoin, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
