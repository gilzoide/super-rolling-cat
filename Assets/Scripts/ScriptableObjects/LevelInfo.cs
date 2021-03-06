﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public string sceneName;
    public float timer = 60f;
}
