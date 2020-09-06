using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public LevelInfo levelInfo;
    public Score currentLevelScore;
    public Score fullGameplayScore;
    public PlayerMovement playerMovement;
    public LevelTimer levelTimer;

    void Awake()
    {
        currentLevelScore.InitScore();
        if (playerMovement == null)
        {
            playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        }
        if (levelTimer == null)
        {
            levelTimer = GameObject.FindObjectOfType<LevelTimer>();
        }
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
            StartCoroutine(PlayVictoryAndGoToNext());
            playerMovement.StopBody();
            playerMovement.enabled = false;
            levelTimer.enabled = false;
        }
    }

    IEnumerator PlayVictoryAndGoToNext()
    {
        yield return new WaitForSeconds(MusicController.PlayVictoryTheme());
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex + 1);
    }
}
