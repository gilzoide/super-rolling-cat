using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public PointsCounter pointsCounter;
    public int pointsAdded = 1;

    void Awake()
    {
        if (!pointsCounter)
        {
            pointsCounter = GameObject.FindObjectOfType<PointsCounter>();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            pointsCounter.AddPoints(pointsAdded);
            Destroy(gameObject);
        }
    }
}
