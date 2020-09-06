using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public PointsCounter pointsCounter;
    public Coin[] allCoins;

    void Awake()
    {
        if (pointsCounter == null)
        {
            pointsCounter = GameObject.FindObjectOfType<PointsCounter>();
        }
        if (allCoins == null || allCoins.Length == 0)
        {
            allCoins = GetComponentsInChildren<Coin>();
        }
    }

    public void Restart()
    {
        foreach (var coin in allCoins)
        {
            coin.gameObject.SetActive(true);
        }
        pointsCounter.Refresh();
    }

    public void OnCoinCollected(Coin coin)
    {
        coin.gameObject.SetActive(false);
        pointsCounter.AddPoints(coin.pointsAdded);
    }
}
