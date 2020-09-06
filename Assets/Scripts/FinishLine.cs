using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public LevelInfo levelInfo;
    public Score currentLevelScore;
    public Score fullGameplayScore;

    void Start()
    {
        currentLevelScore.InitScore();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            fullGameplayScore.AddScore(currentLevelScore);
            SceneManager.LoadScene(levelInfo.nextSceneName);
        }
    }
}
