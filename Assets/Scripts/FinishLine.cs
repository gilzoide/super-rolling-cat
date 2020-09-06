using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public LevelInfo levelInfo;
    public Score currentLevelScore;
    public Score fullGameplayScore;

    void Awake()
    {
        currentLevelScore.InitScore();
    }

    void Start()
    {
        MusicController.PlayGameplayTheme();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            fullGameplayScore.AddScore(currentLevelScore);
            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.buildIndex + 1);
        }
    }
}
