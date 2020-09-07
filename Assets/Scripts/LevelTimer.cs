using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public Score score;
    public FinishLine finishLine;
    public Text text;
    public UnityEvent onTimeOut;

    private float time;

    void Awake()
    {
        if (!finishLine)
        {
            finishLine = GameObject.FindObjectOfType<FinishLine>();
        }
        if (!text)
        {
            text = GetComponent<Text>();
        }
        time = finishLine.levelInfo.timer;
        text.text = time.ToString("f2");
    }

    public void Restart()
    {
        time = finishLine.levelInfo.timer;
        text.text = time.ToString("f2");
        enabled = true;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            time = 0f;
            enabled = false;
            onTimeOut.Invoke();
        }
        else
        {
            score.time += Time.deltaTime;
        }
        
        if (text != null)
        {
            text.text = time.ToString("f2");
        }
    }
}
