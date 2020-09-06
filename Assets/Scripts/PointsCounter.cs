using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    public Text text;
    public Score score;

    void Awake()
    {
        if (!text)
        {
            text = GetComponent<Text>();
        }
    }

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        text.text = score.points.ToString();
    }

    public void AddPoints(int quantity = 1)
    {
        score.AddPoints(quantity);
        Refresh();
    }
}
