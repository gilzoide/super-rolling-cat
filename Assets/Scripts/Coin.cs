using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public CoinCollection coinCollection;
    public int pointsAdded = 1;

    void Awake()
    {
        if (coinCollection == null)
        {
            coinCollection = GetComponentInParent<CoinCollection>();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            coinCollection.OnCoinCollected(this);
        }
    }
}
