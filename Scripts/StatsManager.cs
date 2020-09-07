using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public int score;
    public int coinCount;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI balastext;
    public TextMeshProUGUI scoreText;

    public int balas;

    private void Start()
    {
        coinText.text = "x " + coinCount;
        balastext.text = "x " + balas;
        scoreText.text = "Score: " + score;
    }

    public void UpdateCoin(int coin)
    {
        coinCount += coin;
        coinText.text = "x" + coinCount;
    }

    public void UpdateScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;

    }

    public void UpdateAmmo(int ammo)
    {
        balas = ammo;
        balastext.text = "x " + balas;
    }
}
