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
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
