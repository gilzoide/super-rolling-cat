using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenuController : MonoBehaviour
{
    public Score gameplayScore;
    public Text statsText;

    void Start()
    {
        statsText.text = $"Points: {gameplayScore.points}\nTime: {gameplayScore.time}\nDeaths: {gameplayScore.deaths}\n";
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        MusicController.PlayVictoryTheme();
        yield return new WaitForSeconds(4f);
        MusicController.PlayMenuTheme();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
