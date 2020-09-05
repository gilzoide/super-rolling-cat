﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score")]
public class Score : ScriptableObject
{
    public int deaths;
    public float time;
    public int points;

    public void InitScore()
    {
        deaths = 0;
        time = 0f;
        points = 0;
    }

    public void PlayerDied()
    {
        deaths++;
    }
}
